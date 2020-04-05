using System;
using System.Security.Cryptography;
using System.Text;

namespace Fingerprinty
{
    /// <summary>
    /// Default <see cref="FingerprintProvider"/> based on SHA 256 hash function.
    /// </summary>
    internal class Sha512FingerprintFactory : FingerprintFactory
    {
        /// <inheritdoc />
        public override Fingerprint Create(byte[] bytes)
        {
            if (bytes.Length == 0)
            {
                throw new ArgumentException("Provided value cannot have Length equal 0.", nameof(bytes));
            }

            var hashText = ComputeHash(bytes);
            var fingerprintValue = Transform(hashText);

            return new Fingerprint(fingerprintValue);
        }

        private static string ComputeHash(byte[] bytes)
        {
            var stringBuilder = new StringBuilder(64);

            using (var sha256 = new SHA512Managed())
            {
                var hash = sha256.ComputeHash(bytes);

                foreach (var b in hash) stringBuilder.Append(b.ToString("x2"));
            }

            var result = stringBuilder.ToString();

            return result;
        }

        private static string Transform(string hashText)
        {
            var shortened = hashText.Substring(0, 16);

            var split = shortened.Split(4);

            var joined = string.Join("-", split);

            return joined;
        }
    }
}