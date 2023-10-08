using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Activity1V2
{
    internal class PasswordEncrypter
    {
        public static string hashPassword(string password)
        {
            var sha = SHA256.Create();
            var asBytesArray = Encoding.Default.GetBytes(password);
            var hashedPassword = sha.ComputeHash(asBytesArray);
            return Convert.ToBase64String(hashedPassword);
        }

        public static string fixedSaltPassword(string password, string salt)
        {
            var sha = SHA256.Create();
            var asBytesArray = Encoding.Default.GetBytes(password + salt);
            var hashedPassword = sha.ComputeHash(asBytesArray);
            return Convert.ToBase64String(hashedPassword);
        }

        public static string randomSaltPassword(string password, string randomSalt)
        {
            var sha = SHA256.Create();
            var asBytesArray = Encoding.Default.GetBytes(password + randomSalt);
            var hashedPassword = sha.ComputeHash(asBytesArray);
            return Convert.ToBase64String(hashedPassword);
        }

        public static string generateSalt()
        {
            byte[] saltBytes = new byte[8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }
    }
}
