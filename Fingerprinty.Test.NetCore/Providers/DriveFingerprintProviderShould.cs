using FluentAssertions;
using Xunit;

namespace Fingerprinty.Test.NetCore.Providers
{
    public class DriveFingerprintProviderShould : AllHardwareProvidersShould
    {
        protected override FingerprintProvider FingerprintProvider { get; } =
            FingerprintProviderFactory.Default.CreateDriveProvider();

        [Fact]
        public void SupportOnlyWindows()
        {
            FingerprintProvider.SupportedPlatforms.Should().Be(SupportedPlatforms.Windows);
        }
    }
}