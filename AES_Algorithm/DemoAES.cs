using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AES_Algorithm
{
    public class DemoAES
    {
        AesCryptoServiceProvider cryptoServiceProvider;

        public DemoAES()
        {
            cryptoServiceProvider = new AesCryptoServiceProvider();

            cryptoServiceProvider.BlockSize = 128;
            cryptoServiceProvider.KeySize = 256;
            cryptoServiceProvider.GenerateIV();
            cryptoServiceProvider.GenerateKey();
            cryptoServiceProvider.Mode = CipherMode.CBC;
            cryptoServiceProvider.Padding = PaddingMode.PKCS7;
        }

        public String Encrypt(String clearText)
        {
            ICryptoTransform cryptoTransform = cryptoServiceProvider.CreateEncryptor();

            byte[] encryptedBytes = cryptoTransform.TransformFinalBlock(ASCIIEncoding.ASCII.GetBytes(clearText), 0, clearText.Length);
            string result = Convert.ToBase64String(encryptedBytes);

            return result;
        }

        public String Decrypt(String cipherText)
        {
            ICryptoTransform cryptoTransform = cryptoServiceProvider.CreateDecryptor();

            byte[] encryptedBytes = Convert.FromBase64String(cipherText);
            byte[] decryptedBytes = cryptoTransform.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);

            string result = ASCIIEncoding.ASCII.GetString(decryptedBytes);
            
            return result;
        }
    }
}
