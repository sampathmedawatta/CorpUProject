using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Common
{
    public class AuthenticationOptions
    {
        private readonly PasswordSettings _passwordConfig;

        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;
        Password Password;
        public AuthenticationOptions(PasswordSettings passwordConfig)
        {
            this._passwordConfig = passwordConfig;
        }
        public Password GeneratePassword(bool useLowercase, bool useUppercase, bool useNumbers, bool useSpecial,
            int passwordSize)
        {
            string pass = SetPassword(useLowercase, useUppercase, useNumbers, useSpecial, passwordSize);

            return ConvertPasswordToHash( pass);
        }

        public Password ConvertPasswordToHash(string _password)
        {
            string hashedPassword = HashPasword(_password, out byte[] salt);
            string slt = Convert.ToHexString(salt);

            Password = new Password()
            {
                Hash = hashedPassword,
                Salt = slt,
            };

            return Password;
        }

        private string SetPassword(bool useLowercase, bool useUppercase, bool useNumbers, bool useSpecial,
            int passwordSize)
        {
            char[] _password = new char[passwordSize];
            string charSet = ""; // Initialise to blank
            System.Random _random = new Random();
            int counter;

            // Build up the character set to choose from
            if (useLowercase) charSet += _passwordConfig.LowerCase;

            if (useUppercase) charSet += _passwordConfig.UpperCase;

            if (useNumbers) charSet += _passwordConfig.Numbers;

            if (useSpecial) charSet += _passwordConfig.Specials;

            for (counter = 0; counter < passwordSize; counter++)
            {
                _password[counter] = charSet[_random.Next(charSet.Length - 1)];
            }

            return String.Join(null, _password);
        }

        private string HashPasword(string password, out byte[] salt)
        {
            salt = RandomNumberGenerator.GetBytes(_passwordConfig.Hash.keySize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                _passwordConfig.Hash.iterations,
                hashAlgorithm,
                _passwordConfig.Hash.keySize);
            return Convert.ToHexString(hash);
        }

        private bool VerifyPassword(string password, string hash, byte[] salt)
        {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, _passwordConfig.Hash.iterations, hashAlgorithm, _passwordConfig.Hash.keySize);
            return hashToCompare.SequenceEqual(Convert.FromHexString(hash));
        }
    }
}
