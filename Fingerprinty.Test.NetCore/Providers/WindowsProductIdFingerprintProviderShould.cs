using FluentAssertions;
using Xunit;

namespace Fingerprinty.Test.NetCore.Providers
{
    public class WindowsProductIdFingerprintProviderShould : AllHardwareProvidersShould
    {
        protected override FingerprintProvider FingerprintProvider { get; } =
            FingerprintProviderFactory.Default.CreateWindowsProductIdProvider();

        [Fact]
        public void SupportOnlyWindows()
        {
            FingerprintProvider.SupportedPlatforms.Should().Be(SupportedPlatforms.Windows);
        }
    }
}