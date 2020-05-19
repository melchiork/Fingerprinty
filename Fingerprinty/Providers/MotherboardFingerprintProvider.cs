using System;
using System.Linq;
using System.Management;

namespace Fingerprinty
{
    /// <summary>
    ///     Provides <see cref="Fingerprint" /> based on motherboard's serial.
    /// </summary>
    public class MotherboardFingerprintProvider : FingerprintProvider
    {
        /// <inheritdoc />
        public MotherboardFingerprintProvider(FingerprintFactory fingerprintFactory) : base(fingerprintFactory)
        {
        }

        /// <inheritdoc />
        public override Fingerprint Get()
        {
            try
            {
                var managementObjectSearcher = new ManagementObjectSearcher("Select * From Win32_BaseBoard");

                var motherboardManagementObject =
                    managementObjectSearcher
                        .Get()
                        .Cast<ManagementBaseObject>()
                        .FirstOrDefault();

                var serial = motherboardManagementObject?["SerialNumber"].ToString();

                return FingerprintFactory.Create(serial);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Unable to calculate fingerprint based on motherboard serial number.", ex);
            }
        }

        /// <inheritdoc />
        public override SupportedPlatforms SupportedPlatforms { get; } = SupportedPlatforms.Windows;
    }
}