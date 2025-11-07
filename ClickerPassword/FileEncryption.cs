using System;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows.Forms;

namespace ClickerPassword
{

    public class FileEncryption
    {
        private static byte[] GenerateKeyFromPassword(string password, string username)
        {
            if (string.IsNullOrEmpty(username)) throw new ArgumentException("Username cannot be null or empty.");
            if (string.IsNullOrEmpty(password)) throw new ArgumentException("Password cannot be null or empty.");

            byte[] salt = GenerateSaltFromUsername(username);

            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100_000))
            {
                byte[] aesKey = pbkdf2.GetBytes(32);
                return aesKey;
            }
        }

        private static byte[] GenerateSaltFromUsername(string username)
        {
            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(username));
            }
        }

        private static byte[] Encrypt(string password, string username, byte[] data)
        {
            using (var aes = Aes.Create())
            {
                var key = GenerateKeyFromPassword(password, username);
                aes.Key = key;
                aes.GenerateIV();

                using (var encryptor = aes.CreateEncryptor())
                using (var ms = new MemoryStream())
                {
                    ms.Write(aes.IV, 0, aes.IV.Length);
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        cs.Write(data, 0, data.Length);
                    }
                    return ms.ToArray();
                }
            }
        }

        private static byte[] Decrypt(string password, string username, byte[] data)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = GenerateKeyFromPassword(password, username);
                using (var ms = new MemoryStream(data))
                {
                    byte[] iv = new byte[16];
                    ms.Read(iv, 0, iv.Length);
                    aes.IV = iv;

                    using (var decryptor = aes.CreateDecryptor())
                    using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    using (var resultStream = new MemoryStream())
                    {
                        cs.CopyTo(resultStream);
                        return resultStream.ToArray();
                    }
                }
            }
        }

        private static Dictionary<string, byte[]> LoadFile(string password, string username, String filePath)
        {
            if (!File.Exists(filePath))
                return new Dictionary<string, byte[]>();

            byte[] encryptedData = File.ReadAllBytes(filePath);
            byte[] decryptedData = Decrypt(password, username, encryptedData);

            using (var ms = new MemoryStream(decryptedData))
            {
                var formatter = new BinaryFormatter();
                return (Dictionary<string, byte[]>)formatter.Deserialize(ms);
            }
        }

        private static void SaveFile(string password, string username, String filePath, Dictionary<string, byte[]> map)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, map);
                byte[] encryptedData = Encrypt(password, username, ms.ToArray());
                File.WriteAllBytes(filePath, encryptedData);
            }
        }

        public static string GenerateFileName(string password, string username)
        {
            if (string.IsNullOrEmpty(username)) throw new ArgumentException("Username cannot be null or empty.");
            if (string.IsNullOrEmpty(password)) throw new ArgumentException("Password cannot be null or empty.");

            string input = username + ":" + password;

            using (var sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                string hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                return $"data_{hash}.dat";
            }
        }

        public static void AddEntry(string password, string username, Data data)
        {
            String filePath = GenerateFileName(password, username);
            var map = LoadFile(password, username, filePath);

            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, data);
                map[data.ownName] = ms.ToArray();
            }

            SaveFile(password, username, filePath, map);
        }

        public static Data GetEntry(string password, string username, string key)
        {
            String filePath = GenerateFileName(password, username);
            var map = LoadFile(password, username, filePath);

            if (!map.ContainsKey(key))
                throw new KeyNotFoundException("Key not found.");

            byte[] serializedData = map[key];
            using (var ms = new MemoryStream(serializedData))
            {
                var formatter = new BinaryFormatter();
                return (Data)formatter.Deserialize(ms);
            }
        }

        public static bool ContainsKey(string password, string username, string key)
        {
            String filePath = GenerateFileName(password, username);
            var map = LoadFile(password, username, filePath);
            return map.ContainsKey(key);
        }

        public static List<string> getAllKeys(string password, string username)
        {
            String filePath = GenerateFileName(password, username);
            var map = LoadFile(password, username, filePath);
            return new List<string>(map.Keys);
        }

        public static void RemoveEntry(string password, string username, string key)
        {
            String filePath = GenerateFileName(password, username);
            var map = LoadFile(password, username, filePath);
            map.Remove(key);
            SaveFile(password, username, filePath, map);
        }

        internal static void UpdatePasswordEntry(string password, string username, string key, Data newData)
        {
            String filePath = GenerateFileName(password, username);
            var map = LoadFile(password, username, filePath);

            if (!map.ContainsKey(key))
                throw new KeyNotFoundException("Key not found.");

            Data oldData = null;
            byte[] serializedData = map[key];
            using (var ms = new MemoryStream(serializedData))
            {
                var formatter = new BinaryFormatter();
                oldData = (Data)formatter.Deserialize(ms);
            }

            if(oldData.ownName == newData.ownName
                && oldData.username == newData.username 
                && oldData.widnowTitle == newData.widnowTitle
                && oldData.isStrictWidnow == newData.isStrictWidnow
                && oldData.password != newData.password)
            {
                oldData.password = newData.password;
                using (var ms = new MemoryStream())
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(ms, oldData);
                    map[oldData.ownName] = ms.ToArray();
                }
                SaveFile(password, username, filePath, map);
            } else
            {
                MessageBox.Show("Your data to update is not match to previous data. Please remove old record and add new one",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}
