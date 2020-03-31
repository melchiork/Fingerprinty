using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;

namespace Fingerprinty.HDD
{
    internal class WindowsDriveSerialService : IWindowsDriveSerialService
    {
        public Dictionary<char, string> GetDrivesSerial(params char[] driveLetters)
        {
            if (driveLetters.Length < 1)
            {
                throw new ArgumentException("The must be at least one drive letter provided.");
            }

            var serials = driveLetters
                .Select(x => new {DriveLetter = x, VolumeSerial = GetVolumeSerial(x)})
                .ToDictionary(x => x.DriveLetter, x => x.VolumeSerial);

            return serials;
        }

        private static string GetVolumeSerial(char driveLetter)
        {
            string volumeSerial;
            try
            {
                using (var disk = new ManagementObject($@"win32_logicaldisk.deviceid=""{char.ToLower(driveLetter)}:"""))
                {
                    disk.Get();
                    volumeSerial = disk["VolumeSerialNumber"].ToString();
                    disk.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Not possible to find disk {driveLetter}:.", ex);
            }

            if (string.IsNullOrEmpty(volumeSerial))
            {
                throw new InvalidOperationException($"Volume Serial Number for drive '{driveLetter}' is null or empty.");
            }

            return volumeSerial;
        }
    }
}
