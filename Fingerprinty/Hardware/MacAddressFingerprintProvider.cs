using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace Fingerprinty.Hardware
{
    public class MacAddressFingerprintProvider : HardwareFingerprintProvider
    {
        public override HardwareFingerprint Get()
        {
            var allCombinedMAcAddresses = GetAllCombinedMacAddresses();

            var addressesText = Encoding.UTF8.GetString(allCombinedMAcAddresses);

            return FingerprintFactory.Create(addressesText);
        }

        public override SupportedPlatforms SupportedPlatforms { get; } =
            SupportedPlatforms.Linux | SupportedPlatforms.Windows;

        private static byte[] GetAllCombinedMacAddresses()
        {
            var allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            if (allNetworkInterfaces.Length < 1) throw new FingerprintyException("No network interfaces found.");

            var macAddressBytes =
                allNetworkInterfaces
                    .OrderBy(x => x.Id)
                    .Select(x => x.GetPhysicalAddress().GetAddressBytes())
                    .SelectMany(x => x)
                    .ToArray();

            return macAddressBytes;
        }
    }
}