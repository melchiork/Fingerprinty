using System;
using System.Management;

namespace Fingerprinty
{
    public class DriveFingerprintProvider : FingerprintProvider
    {
        public override SupportedPlatforms SupportedPlatforms { get; } = SupportedPlatforms.Windows;

        public DriveFingerprintProvider(FingerprintFactory fingerprintFactory) : base(fingerprintFactory)
        {
        }

        public override Fingerprint Get()
        {
            var cDriveSerial = GetCDriveSerial();

            return FingerprintFactory.Create(cDriveSerial);
        }

        private static string GetCDriveSerial()
        {
            string volumeSerial;

            try
            {
                using (var disk = new ManagementObject(@"win32_logicaldisk.deviceid=""C:"""))
                {
                    disk.Get();
                    volumeSerial = disk["VolumeSerialNumber"].ToString();
                    disk.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Not possible to find disk C:.", ex);
            }

            if (string.IsNullOrEmpty(volumeSerial))
            {
                throw new InvalidOperationException("Volume Serial Number for cDrive is null or empty.");
            }

            return volumeSerial;
        }
    }
}