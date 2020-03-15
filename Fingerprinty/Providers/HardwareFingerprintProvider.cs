using System;

namespace Fingerprinty.Providers
{
    internal class HardwareFingerprintProvider : IFingerprintProvider
    {
        public string Get()
        {
            return "a";
        }
    }
}