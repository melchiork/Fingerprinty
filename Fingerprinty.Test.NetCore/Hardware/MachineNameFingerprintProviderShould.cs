using Fingerprinty.Hardware;
using FluentAssertions;
using Xunit;

namespace Fingerprinty.Test.NetCore.Hardware
{
    public class MachineNameFingerprintProviderShould : AllHardwareProvidersShould
    {
        protected override HardwareFingerprintProvider FingerprintProvider { get; } =
            new MachineNameFingerprintProvider();

        [Fact]
        public void SupportLinuxAndWindows()
        {
            FingerprintProvider.SupportedPlatforms.Should().Be(SupportedPlatforms.Windows | SupportedPlatforms.Linux);
        }
    }
}