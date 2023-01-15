using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Core.Utilities.Security.Hashing
{
    public class PasswordHash
    {
        private const int keySize = 64;
        private const int iterations = 10000;

        public string GenerateSaltHash()
        {
            var salt = RandomNumberGenerator.GetBytes(keySize);
            return Convert.ToBase64String(salt);
        }

        public string HashPassword(string password, string salt) 
        {
            var hash = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(password), Encoding.UTF8.GetBytes(salt), iterations, HashAlgorithmName.SHA512, keySize);
            return Convert.ToBase64String(hash);
        }

        public bool VerifyPassword(string password, string hash, string salt) 
        {
            return HashPassword(password, salt) == hash;
        }
    }
}
