using Fingerprinty.Hardware;
using FluentAssertions;
using Xunit;

namespace Fingerprinty.Test.NetCore.Hardware
{
    public class DriveFingerprintProviderShould : AllHardwareProvidersShould
    {
        protected override HardwareFingerprintProvider FingerprintProvider { get; } = new DriveFingerprintProvider();

        [Fact]
        public void SupportOnlyWindows()
        {
            FingerprintProvider.SupportedPlatforms.Should().Be(SupportedPlatforms.Windows);
        }
    }
}