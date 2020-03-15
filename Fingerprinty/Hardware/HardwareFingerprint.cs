using System;
using System.Security.Cryptography;
using System.Text;

namespace Fingerprinty.Hardware
{
    public abstract class HardwareFingerprint
    {
        protected readonly Func<string, string> HashFunc;

        private static int IdentifierLength { get; } = 32;

        protected HardwareFingerprint()
        {
            HashFunc = ComputeHash;
        }

        private static string ComputeHash(string value)
        {
            var stringBuilder = new StringBuilder(64);

            using (var sha256 = new SHA256Managed())
            {
                var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(value));

                foreach (var b in hash) stringBuilder.Append(b.ToString("x2"));
            }

            var result = stringBuilder.ToString().Substring(0, IdentifierLength);

            return result;
        }
    }
}