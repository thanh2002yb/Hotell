using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace StartHotell.Common
{
    public static class MD5
    {
        public static string GetMD5(string str)
        {
            System.Security.Cryptography.MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] tagetdata = md5.ComputeHash(fromData);
            string byte2String = null;
            for (int i = 0; i < tagetdata.Length; i++)
            {
                byte2String += tagetdata[i].ToString("x2");

            }
            return byte2String;
        }
    }
}