using System.Collections.Generic;

namespace Fingerprinty.HDD
{
    /// <summary>
    /// Abstraction over Windows API for getting drives serial numbers. 
    /// </summary>
    public interface IWindowsDriveSerialService
    {
        /// <summary>
        /// Gets serial number for all drives with assigned drive letter.
        /// </summary>
        /// <param name="driveLetters"></param>
        /// <returns></returns>
        Dictionary<char, string> GetDrivesSerial(params char[] driveLetters);
    }
}