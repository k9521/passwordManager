using OtpNet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ZXing;

namespace PasswordManager
{
    public class Auth2FA
    {
        public static string ReadQrCode(string filePath)
        {
            var reader = new BarcodeReader();
            using (var bitmap = (Bitmap)Image.FromFile(filePath))
            {
                var result = reader.Decode(bitmap);
                return result?.Text;
            }
        }
        public static string ParseSecretFromUrl(string qrContent)
        {
            if (string.IsNullOrEmpty(qrContent)) return null;

            var uri = new Uri(qrContent);
            var queryParams = HttpUtility.ParseQueryString(uri.Query);
            return queryParams["secret"];
        }
        public static string GeneratePin(string base32Secret)
        {
            byte[] secretBytes = Base32Encoding.ToBytes(base32Secret);
            var totp = new Totp(secretBytes);
            return totp.ComputeTotp();
        }
    }
}
