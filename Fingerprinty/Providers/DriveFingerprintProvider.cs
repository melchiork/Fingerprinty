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
            try
            {
                string volumeSerial;
                using (var disk = new ManagementObject(@"win32_logicaldisk.deviceid=""C:"""))
                {
                    disk.Get();
                    volumeSerial = disk["VolumeSerialNumber"].ToString();
                    disk.Dispose();
                }

                return volumeSerial;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Not possible to find disk C:.", ex);
            }
        }
    }
}