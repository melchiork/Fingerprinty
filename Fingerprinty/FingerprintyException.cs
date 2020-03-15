using System;

namespace Fingerprinty
{
    public class FingerprintyException : Exception
    {
        public FingerprintyException(string message, Exception ex) : base(message, ex)
        {
        }

        public FingerprintyException(string message) : base(message)
        {
        }
    }
}