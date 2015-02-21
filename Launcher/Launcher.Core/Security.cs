using System;
using System.Security.Cryptography;
using System.Text;

namespace Launcher.Core
{
    public class Security
    {
        private static readonly string _salt = "!@#ф$ы%в^а&чQяWERasdfg789456";
        // ReSharper disable once InconsistentNaming
        public static string GetSHA512(string text)
        {
            var UE = new UnicodeEncoding();
            byte[] hashValue;
            var message = UE.GetBytes(text + _salt);

            var hashString = new SHA512Managed();
            var hex = "";

            hashValue = hashString.ComputeHash(message);
            foreach (var x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        }
    }
}