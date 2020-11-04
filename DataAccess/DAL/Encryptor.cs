using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAL
{
    public class Encryptor
    {
        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            byte[] res = md5.Hash;
            StringBuilder str = new StringBuilder();

            for (int i = 0; i < res.Length; i++)
            {
                str.Append(res[i].ToString("x2"));
            }
            return str.ToString();

        }


    }
}
