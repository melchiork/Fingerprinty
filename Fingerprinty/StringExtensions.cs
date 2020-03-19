using System.Collections.Generic;
using System.Linq;

namespace Fingerprinty
{
    internal static class StringExtensions
    {
        public static IEnumerable<string> Split(this string input, int chunkSize)
        {
            return Enumerable.Range(0, input.Length / chunkSize)
                .Select(i => input.Substring(i * chunkSize, chunkSize));
        }
    }
}