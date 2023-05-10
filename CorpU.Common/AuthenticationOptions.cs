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

        // TODO get this from app settings
        //const string LOWER_CASE = "abcdefghijklmnopqursuvwxyz";
        //const string UPPER_CAES = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        //const string NUMBERS = "123456789";
        //const string SPECIALS = @"!@£$%^&*()#€";

        //const int keySize = 64;
        //const int iterations = 350000;

        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        public AuthenticationOptions(PasswordSettings passwordConfig)
        {
            this._passwordConfig = passwordConfig;
        }
        public string GeneratePassword(bool useLowercase, bool useUppercase, bool useNumbers, bool useSpecial,
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
        
        public string HashPasword(string password, out byte[] salt)
        {
            salt = RandomNumberGenerator.GetBytes(_passwordConfig.keySize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                _passwordConfig.iterations,
                hashAlgorithm,
                _passwordConfig.keySize);
            return Convert.ToHexString(hash);
        }

        public bool VerifyPassword(string password, string hash, byte[] salt)
        {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, _passwordConfig.iterations, hashAlgorithm, _passwordConfig.keySize);
            return hashToCompare.SequenceEqual(Convert.FromHexString(hash));
        }
    }
}
