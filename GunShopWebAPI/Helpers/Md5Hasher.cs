using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GunShopWebAPI.Helpers
{
    public class Md5Hasher
    {
        public string GetMd5Hash(string input)
        {
            MD5CryptoServiceProvider hasher = new MD5CryptoServiceProvider();
            byte[] data = hasher.ComputeHash(Encoding.Default.GetBytes(input));

            var sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString("x2"));
            }

            return sb.ToString();
        }

        public bool CompareHash(string input, string hash)
        {
            var inputHash = GetMd5Hash(input);

            if (string.Equals(inputHash, hash))
                return true;

            return false;
        }
    }
}
