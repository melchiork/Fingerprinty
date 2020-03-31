using System;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace Fingerprinty
{
    /// <summary>
    /// Calculates <see cref="Fingerprint"/> based on combined mac addresses of all attached network cards.
    /// The MAC addresses will be always processed in the same sequence.
    /// </summary>
    public class AllMacAddressesFingerprintProvider : FingerprintProvider
    {
        public AllMacAddressesFingerprintProvider(FingerprintFactory fingerprintFactory) : base(fingerprintFactory)
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