using System;
using System.Security.Cryptography;
using System.Text;
using WalletPlanifier.Common.Services.Contracts;

namespace WalletPlanifier.Common.Services
{
    public class CryptographyService : ICryptographyService
    {
        public string Decrypt(string text, string hash)
        {
            string response;
            byte[] data = Convert.FromBase64String(text);

            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                //Decrypt data by hash key
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    response = UTF8Encoding.UTF8.GetString(results);
                }
            }

            return response;
        }

        public string Encrypt(string text, string hash)
        {
            string response;
            byte[] data = UTF8Encoding.UTF8.GetBytes(text);

            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                //Encrypt data by hash key
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    response = Convert.ToBase64String(results, 0, results.Length);
                }
            }

            return response;
        }
    }
}
