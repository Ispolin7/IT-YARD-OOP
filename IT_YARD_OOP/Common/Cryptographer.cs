using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace IT_YARD.Common
{
    /// <summary>
    /// Encrypt/Decrypt information
    /// </summary>
    static class Cryptographer
    {
        /// <summary>
        /// Class fields
        /// </summary>
        static byte[] Key { get; }
        static byte[] Iv { get; }

        /// <summary>
        /// Cryptographer static constructor
        /// </summary>
        static Cryptographer()
        {
            using (RijndaelManaged myRijndael = new RijndaelManaged())
            {
                myRijndael.GenerateKey();
                myRijndael.GenerateIV();
                Key = myRijndael.Key;
                Iv = myRijndael.IV;
            }
        }

        /// <summary>
        /// Encrypt information
        /// </summary>
        /// <param name="text"></param>
        /// <returns>encrypt string</returns>
        public static string Encrypt(string text)
        {
            byte[] encrypted;
            using (RijndaelManaged rijAlg = new RijndaelManaged())
            {
                rijAlg.Key = Key;
                rijAlg.IV = Iv;
                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(text);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            return Convert.ToBase64String(encrypted);
        }

        /// <summary>
        /// Decrypt information
        /// </summary>
        /// <param name="text"></param>
        /// <returns>decrypt string</returns>
        public static string Decrypt(string text)
        {
            byte[] cipherText = Convert.FromBase64String(text);
            string plaintext = null;
            using (RijndaelManaged rijAlg = new RijndaelManaged())
            {
                rijAlg.Key = Key;
                rijAlg.IV = Iv;
                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return plaintext;
        }
    }
}
