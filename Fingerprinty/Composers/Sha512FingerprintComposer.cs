using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Fingerprinty.Composers
{
    /// <summary>
    /// TODO Docs
    /// </summary>
    public class Sha512FingerprintComposer : FingerprintComposer
    {
        /// <summary>
        /// TODO Docs
        /// </summary>
        /// <param name="components"></param>
        /// <returns></returns>
        public override string Compose(List<string> components)
        {
            var bytes = Encoding.UTF8.GetBytes(string.Join(string.Empty, components));

            byte[] hash;
            using (var sha512 = new SHA512Managed())
            {
                hash = sha512.ComputeHash(bytes);
            }

            var stringBuilder = new StringBuilder(64);

            foreach (var b in hash)
            {
                stringBuilder.Append(b.ToString("x2"));
            }

            var result = stringBuilder.ToString();

            return result;
        }
    }
}
