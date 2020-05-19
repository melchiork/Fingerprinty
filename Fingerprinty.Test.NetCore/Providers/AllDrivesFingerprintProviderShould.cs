using FluentAssertions;
using Xunit;

namespace Fingerprinty.Test.NetCore.Providers
{
    public class AllDrivesFingerprintProviderShould : AllFingerprintProvidersShould
    {
        protected override FingerprintProvider FingerprintProvider { get; } =
            FingerprintProviderFactory.Default.CreateAllDrivesProvider();

        [Fact]
        public void SupportOnlyWindows()
        {
            FingerprintProvider.SupportedPlatforms.Should().Be(SupportedPlatforms.Windows);
        }
    }
}