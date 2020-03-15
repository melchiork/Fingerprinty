using Fingerprinty.Hardware;
using FluentAssertions;
using Xunit;

namespace Fingerprinty.Test.NetCore.Hardware
{
    public class WindowsProductIdFingerprintShould : AllHardwareProvidersShould
    {
        protected override IHardwareFingerprintProvider FingerprintProvider { get; } = new WindowsProductIdFingerprint();

        [Fact]
        public void SupportOnlyWindows()
        {
            FingerprintProvider.SupportedPlatforms.Should().Be(SupportedPlatforms.Windows);
        }
    }
}