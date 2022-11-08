using System;
using System.Security.Cryptography;
using System.Text;

namespace JWTDemo.Utils
{
    public static class AESUtils
    {
        public static string DecryptString(string text, string AESkey, string ARSiv)
        {
            Aes aes = new Aes(AESkey, ARSiv);
            return aes.DecryptFromBase64String(text);
        }
    }
}

