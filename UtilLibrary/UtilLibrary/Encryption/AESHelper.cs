using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace UtilLibrary.Encryption
{
    public class AESHelper
    {
        /// <summary>
        /// AES 加密 Base64 格式的字符串
        /// </summary>
        /// <param name="toEncrypt"></param>
        /// <param name="keyStr"></param>
        /// <returns>Base64 格式的字符串</returns>
        public static string AESEncryptor(string toEncrypt, string keyStr)
        {
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);
            byte[] keyArray = Encoding.UTF8.GetBytes(keyStr);

            RijndaelManaged managed = new RijndaelManaged();
            managed.Key = keyArray;
            managed.Mode = CipherMode.ECB;
            managed.Padding = PaddingMode.PKCS7;

            ICryptoTransform cryptoTransform = managed.CreateEncryptor();
            byte[] resultArray = cryptoTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Convert.ToBase64String(resultArray);
        }

        /// <summary>
        /// AES 解密
        /// </summary>
        /// <param name="toDecrypt"></param>
        /// <param name="keyStr"></param>
        /// <returns></returns>
        public static string AESDecryptor(string toDecrypt, string keyStr)
        {
            byte[] toDecryptArray = Convert.FromBase64String(toDecrypt);
            byte[] keyArray = Encoding.UTF8.GetBytes(keyStr);

            RijndaelManaged managed = new RijndaelManaged();
            managed.Key = keyArray;
            managed.Mode = CipherMode.ECB;
            managed.Padding = PaddingMode.PKCS7;

            ICryptoTransform cryptoTransform = managed.CreateDecryptor();
            byte[] resultArray = cryptoTransform.TransformFinalBlock(toDecryptArray, 0, toDecryptArray.Length);
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
    }
}
