using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace UtilLibrary.Encryption
{
    /// <summary>
    /// DES 帮助类
    /// </summary>
    public class DESHelper
    {
        /// <summary>
        /// DES 加密  以Base64 对外输出
        /// </summary>
        /// <param name="toEncryptString"></param>
        /// <param name="keyStr"></param>
        /// <returns>Base64 格式的字符串</returns>
        public static string DESEncryptor(string toEncryptString, string keyStr)
        {
            using (DESCryptoServiceProvider dES = new DESCryptoServiceProvider())
            {
                if (keyStr.Length < 8)
                    return string.Empty;
                byte[] toEncryptArray = Encoding.UTF8.GetBytes(toEncryptString);

                dES.Key = Encoding.ASCII.GetBytes(keyStr.Substring(0, 8));
                dES.IV = Encoding.ASCII.GetBytes(keyStr.Substring(0, 8));
                MemoryStream memoryStream = new MemoryStream();
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, dES.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cryptoStream.Write(toEncryptArray, 0, toEncryptArray.Length);
                    cryptoStream.FlushFinalBlock();
                }
                string returnBase64String = Convert.ToBase64String(memoryStream.ToArray());
                memoryStream.Close();
                return returnBase64String;
            }
        }

        /// <summary>
        ///  DES 解密
        /// </summary>
        /// <param name="toDecryptString">DES加密的 Base64 字符串</param>
        /// <param name="keyStr"></param>
        /// <returns></returns>
        public static string DESDecryptor(string toDecryptString, string keyStr)
        {
            using (DESCryptoServiceProvider dES = new DESCryptoServiceProvider())
            {
                if (keyStr.Length < 8)
                    return string.Empty;
                byte[] toDecryptArray = Convert.FromBase64String(toDecryptString);
                dES.Key = Encoding.ASCII.GetBytes(keyStr.Substring(0, 8));
                dES.IV = Encoding.ASCII.GetBytes(keyStr.Substring(0, 8));
                MemoryStream memoryStream = new MemoryStream();
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, dES.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cryptoStream.Write(toDecryptArray, 0, toDecryptArray.Length);
                    cryptoStream.FlushFinalBlock();
                }
                string returnString = Encoding.UTF8.GetString(memoryStream.ToArray());
                memoryStream.Close();
                return returnString;
            }
        }

    }
}
