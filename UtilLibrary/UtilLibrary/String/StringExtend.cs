using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UtilLibrary.String
{
    /// <summary>
    /// 字符串的扩展
    /// </summary>
    public static class StringExtend
    {
        /// <summary>
        ///  字符串 转化为 二进制字符串
        /// </summary>
        /// <param name="str">普通字符串</param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string StringToBinary(this string str, Encoding encoding)
        {
            byte[] strBytes = encoding.GetBytes(str);
            StringBuilder stringBuilder = new StringBuilder(strBytes.Length * 8);
            foreach (var data in strBytes)
            {
                string x = Convert.ToString(data, 2);//先转化为二进制 字符
                string y = x.PadLeft(8, '0'); //满足8位 不足的用0补位
                stringBuilder.Append(y);
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// 二进制 字符串 转化为 普通字符串
        /// </summary>
        /// <param name="binaryString"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string BinaryToString(this string binaryString, Encoding encoding)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int numberOfBytes = binaryString.Length / 8;
            byte[] strBytes = new byte[numberOfBytes];
            for (int i = 0; i < numberOfBytes; i++)
            {
                strBytes[i] = Convert.ToByte(binaryString.Substring(i * 8, 8), 2);
            }
            return encoding.GetString(strBytes);
        }

    }
}
