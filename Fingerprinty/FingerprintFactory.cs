using System;
using System.Text;

namespace Fingerprinty
{
    /// <summary>
    /// Base for factories that can create new <see cref="Fingerprint"/> instances.
    /// </summary>
    public abstract class FingerprintFactory
    {
        /// <summary>
        /// Creates <see cref="Fingerprint"/> instance based on a string.
        /// </summary>
        /// <remarks>
        /// The default version of this method will encode the string using UTF8 and passes them to <see cref="Create(byte[])"/>
        /// </remarks>
        /// <param name="text">The <see cref="string"/> input for fingerprint calculation.</param>
        /// <returns>New see <see cref="Fingerprint"/> instance.</returns>
        /// <exception cref="ArgumentException">Throws when argument is null or empty.</exception>
        public virtual Fingerprint Create(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException("The provided value cannot be null or empty.", nameof(text));
            }

            var bytes = Encoding.UTF8.GetBytes(text);

            return Create(bytes);
        }

        /// <summary>
        /// Creates a <see cref="Fingerprint"/> instance based on array of bytes.
        /// </summary>
        /// <param name="bytes">Byte representation of fingerprint.</param>
        /// <returns></returns>
        public abstract Fingerprint Create(byte[] bytes);
    }
}