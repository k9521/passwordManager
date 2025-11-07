using ClickerPassword;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordManager
{
    internal class LoginManager
    {
        internal static bool Login(string username, string password)
        {
            String fileName = FileEncryption.GenerateFileName(password, username);

            if (File.Exists(fileName))
            {
                return true;
            } else
            {
                DialogResult result = MessageBox
                    .Show("The entered username and password are incorrect.\nDo you want to create a new user with the given username and password?",
                    "User do not exist",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                return (result == DialogResult.Yes);
            }
        }
    }
}
