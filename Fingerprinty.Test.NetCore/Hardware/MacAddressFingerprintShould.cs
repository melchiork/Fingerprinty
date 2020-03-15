using Fingerprinty.Hardware;
using FluentAssertions;
using Xunit;

namespace Fingerprinty.Test.NetCore.Hardware
{
    public class MacAddressFingerprintShould : AllHardwareProvidersShould
    {
        protected override IHardwareFingerprintProvider FingerprintProvider { get; } = new MacAddressFingerprint();

        [Fact]
        public void SupportLinuxAndWindows()
        {
            FingerprintProvider.SupportedPlatforms.Should().Be(SupportedPlatforms.Windows | SupportedPlatforms.Linux);
        }
    }
}