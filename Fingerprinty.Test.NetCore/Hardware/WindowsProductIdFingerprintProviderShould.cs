using Fingerprinty.Hardware;
using FluentAssertions;
using Xunit;

namespace Fingerprinty.Test.NetCore.Hardware
{
    public class WindowsProductIdFingerprintProviderShould : AllHardwareProvidersShould
    {
        protected override HardwareFingerprintProvider FingerprintProvider { get; } = new WindowsProductIdFingerprintProvider();

        [Fact]
        public void SupportOnlyWindows()
        {
            FingerprintProvider.SupportedPlatforms.Should().Be(SupportedPlatforms.Windows);
        }
    }
}