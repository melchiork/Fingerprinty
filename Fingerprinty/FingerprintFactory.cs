using System;
using System.Text;

namespace Fingerprinty
{
    public abstract class FingerprintFactory
    {
        public virtual Fingerprint Create(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException("The provided value cannot be null or empty.", nameof(text));
            }

            var bytes = Encoding.UTF8.GetBytes(text);

            return Create(bytes);
        }

        public abstract Fingerprint Create(byte[] bytes);
    }
}