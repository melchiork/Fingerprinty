using System;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace Fingerprinty
{
    public class MacAddressFingerprintProvider : FingerprintProvider
    {
        public MacAddressFingerprintProvider(FingerprintFactory fingerprintFactory) : base(fingerprintFactory)
        {
        }

        public override Fingerprint Get()
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

            if (allNetworkInterfaces.Length < 1) throw new InvalidOperationException("No network interfaces found.");

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