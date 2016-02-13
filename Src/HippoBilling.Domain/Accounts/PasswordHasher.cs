using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HippoBilling.Domain.Accounts
{
    public class PasswordHasher
    {
        public static string Hash(string saltString, string password)
        {
            var salt = Encoding.UTF8.GetBytes(password);
            var encodedPassword = Encoding.UTF8.GetBytes(password);
            var saltedPassword = new byte[salt.Length + encodedPassword.Length];
            Array.Copy(salt, 0, saltedPassword, 0, salt.Length);
            Array.Copy(encodedPassword, 0, saltedPassword, salt.Length, encodedPassword.Length);
            using (var alg = SHA256.Create())
            {
                return Encoding.UTF8.GetString(alg.ComputeHash(saltedPassword));
            }
        }

        public static HashedPassword HashedPassword(string password)
        {
            var salt = Guid.NewGuid().ToString("N").ToUpper();
            return new HashedPassword()
            {
                Salt = salt,
                Hash = Hash(salt, password)
            };
        }
    }
}
