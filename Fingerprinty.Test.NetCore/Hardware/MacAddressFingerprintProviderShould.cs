using Fingerprinty.Hardware;
using FluentAssertions;
using Xunit;

namespace Fingerprinty.Test.NetCore.Hardware
{
    public class MacAddressFingerprintProviderShould : AllHardwareProvidersShould
    {
        protected override HardwareFingerprintProvider FingerprintProvider { get; } = new MacAddressFingerprintProvider();

        [Fact]
        public void SupportLinuxAndWindows()
        {
            FingerprintProvider.SupportedPlatforms.Should().Be(SupportedPlatforms.Windows | SupportedPlatforms.Linux);
        }
    }
}