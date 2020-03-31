using System.Collections.Generic;

namespace Fingerprinty.HDD
{
    public interface IWindowsDriveSerialService
    {
        Dictionary<char, string> GetDrivesSerial(params char[] driveLetters);
    }
}