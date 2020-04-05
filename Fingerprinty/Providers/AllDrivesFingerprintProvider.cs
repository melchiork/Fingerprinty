using System.IO;
using System.Linq;
using Fingerprinty.HDD;

namespace Fingerprinty
{
    /// <summary>
    /// Calculates <see cref="Fingerprint"/> based on serial numbers of all fixed drives.
    /// The serial numbers will be always processed in the same sequence.
    /// Pendrives, network drives, CD-Roms etc. are not fixed drives.
    /// </summary>
    public class AllDrivesFingerprintProvider : FingerprintProvider
    {
        private readonly IWindowsDriveSerialService _windowsDriveSerialService;

        /// <inheritdoc />
        public AllDrivesFingerprintProvider(FingerprintFactory fingerprintFactory,
            IWindowsDriveSerialService windowsDriveSerialService) : base(fingerprintFactory)
        {
            _windowsDriveSerialService = windowsDriveSerialService;
        }

        /// <inheritdoc />
        public override SupportedPlatforms SupportedPlatforms { get; } = SupportedPlatforms.Windows;

        /// <inheritdoc />
        public override Fingerprint Get()
        {
            var fixedDrives = DriveInfo
                .GetDrives()
                .Where(x => x.DriveType == DriveType.Fixed);

            var fixedDriveLetters = fixedDrives
                .Select(x => x.Name.ToCharArray().FirstOrDefault())
                .Where(char.IsLetter)
                .ToArray();

            var serials = _windowsDriveSerialService
                .GetDrivesSerial(fixedDriveLetters)
                .Select(x => x.Value);

            var orderedUniqueSerials = serials.Distinct().OrderBy(x => x);

            var combinedSerials = string.Join(string.Empty, orderedUniqueSerials);

            return FingerprintFactory.Create(combinedSerials);
        }
    }
}