using System;
using System.Management;

namespace Fingerprinty.Hardware
{
    public class DriveFingerprintProvider : HardwareFingerprintProvider
    {
        public override HardwareFingerprint Get()
        {
            var cDriveSerial = GetCDriveSerial();

            return FingerprintFactory.Create(cDriveSerial);
        }

        private static string GetCDriveSerial()
        {
            try
            {
                var disk = new ManagementObject(@"win32_logicaldisk.deviceid=""C:""");
                disk.Get();

                var volumeSerial = disk["VolumeSerialNumber"].ToString();
                disk.Dispose();

                return volumeSerial;
            }
            catch (Exception ex)
            {
                throw new FingerprintyException("Not possible to find disk C:.", ex);
            }
        }

        public override SupportedPlatforms SupportedPlatforms { get; } = SupportedPlatforms.Windows;
    }
}