using Fingerprinty.HDD;

namespace Fingerprinty
{
    /// <summary>
    /// Calculates <see cref="Fingerprint"/> based on serial number of the c drive.
    /// </summary>
    public class DriveFingerprintProvider : FingerprintProvider
    {
        private readonly IWindowsDriveSerialService _windowsDriveSerialService;

        /// <inheritdoc />
        public override SupportedPlatforms SupportedPlatforms { get; } = SupportedPlatforms.Windows;

        /// <inheritdoc />
        public DriveFingerprintProvider(FingerprintFactory fingerprintFactory, 
            IWindowsDriveSerialService windowsDriveSerialService) : base(fingerprintFactory)
        {
            _windowsDriveSerialService = windowsDriveSerialService;
        }

        /// <inheritdoc />
        public override Fingerprint Get()
        {
            var cDriveSerial = _windowsDriveSerialService.GetDrivesSerial('c')['c'];

            return FingerprintFactory.Create(cDriveSerial);
        }
    }
}