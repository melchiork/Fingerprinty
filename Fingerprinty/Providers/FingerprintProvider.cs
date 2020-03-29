namespace Fingerprinty
{
    public abstract class FingerprintProvider
    {
        private protected readonly HardwareFingerprintFactory FingerprintFactory;

        protected FingerprintProvider(HardwareFingerprintFactory fingerprintFactory)
        {
            FingerprintFactory = fingerprintFactory;
        }

        public abstract HardwareFingerprint Get();

        public abstract SupportedPlatforms SupportedPlatforms { get; }
    }
}