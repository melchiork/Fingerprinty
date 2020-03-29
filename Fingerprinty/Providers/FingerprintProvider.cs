namespace Fingerprinty
{
    public abstract class FingerprintProvider
    {
        private protected readonly FingerprintFactory FingerprintFactory;

        protected FingerprintProvider(FingerprintFactory fingerprintFactory)
        {
            FingerprintFactory = fingerprintFactory;
        }

        public abstract Fingerprint Get();

        public abstract SupportedPlatforms SupportedPlatforms { get; }
    }
}