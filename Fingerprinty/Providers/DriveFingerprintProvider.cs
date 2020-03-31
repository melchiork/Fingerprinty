using Fingerprinty.HDD;

namespace Fingerprinty
{
    public class DriveFingerprintProvider : FingerprintProvider
    {
        private readonly IWindowsDriveSerialService _windowsDriveSerialService;

        public override SupportedPlatforms SupportedPlatforms { get; } = SupportedPlatforms.Windows;

        public DriveFingerprintProvider(FingerprintFactory fingerprintFactory, 
            IWindowsDriveSerialService windowsDriveSerialService) : base(fingerprintFactory)
        {
            _windowsDriveSerialService = windowsDriveSerialService;
        }

        public override Fingerprint Get()
        {
            var cDriveSerial = _windowsDriveSerialService.GetDrivesSerial('c')['c'];

            return FingerprintFactory.Create(cDriveSerial);
        }
    }
}