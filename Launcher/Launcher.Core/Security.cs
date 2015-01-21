using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Launcher
{
    class Security
    {
        private static string _salt = "!@#ф$ы%в^а&чQяWERasdfg789456";
        // ReSharper disable once InconsistentNaming
        public static string GetSHA512(string text)
        {
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] hashValue;
            byte[] message = UE.GetBytes(text+_salt);

            SHA512Managed hashString = new SHA512Managed();
            string hex = "";

            hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        }
    }
}
