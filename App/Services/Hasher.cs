using System;
using System.Linq;
using System.Security.Cryptography;

namespace App.Services
{
    public interface IHasher
    {
        public string Hash (string password);
        public bool Check (string password, string hash);

    }

    public sealed class Hasher : IHasher
    {
        private int iterations = 10000; // Number of iterations
        private const int saltSize = 16; // 128 bit 
        private const int keySize = 32; // 256 bit

        public bool Check (string password, string hash)
        {
            var parts = hash.Split('.', 3);
            var iterations = Convert.ToInt32(parts[0]);
            var salt = Convert.FromBase64String(parts[1]);
            var key = Convert.FromBase64String(parts[2]);

            var algorithm = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256);
            var keyToCheck = algorithm.GetBytes(keySize);

            var isEqual = keyToCheck.SequenceEqual(key);
            return isEqual;

        }
        public string Hash (string password)
        {
            var algorithm = new Rfc2898DeriveBytes(password, saltSize, iterations, HashAlgorithmName.SHA256);
            var key = Convert.ToBase64String(algorithm.GetBytes(keySize));
            var salt = Convert.ToBase64String(algorithm.Salt);
            return $"{iterations}.{salt}.{key}";
        }
    }
}