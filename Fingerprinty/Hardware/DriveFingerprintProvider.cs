using System;
using System.IO;
using System.Management;

namespace Fingerprinty.Hardware
{
    public class DriveFingerprintProvider : HardwareFingerprintProvider
    {
        public override SupportedPlatforms SupportedPlatforms { get; } = SupportedPlatforms.Windows;

        public override HardwareFingerprint Get()
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