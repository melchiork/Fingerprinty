namespace Fingerprinty.Hardware
{
    public abstract class HardwareFingerprintProvider
    {
        private protected readonly HardwareFingerprintFactory FingerprintFactory;

        protected HardwareFingerprintProvider()
        {
            FingerprintFactory = new HardwareFingerprintFactory();
        }

        public abstract HardwareFingerprint Get();

        public abstract SupportedPlatforms SupportedPlatforms { get; }
    }
}