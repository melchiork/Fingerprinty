using FluentAssertions;
using Xunit;

namespace Fingerprinty.Test.NetCore.Providers
{
    public class AllMacAddressesFingerprintProvider : AllFingerprintProvidersShould
    {
        protected override FingerprintProvider FingerprintProvider { get; } 
            = FingerprintProviderFactory.Default.CreateMacAddressProvider();

        [Fact]
        public void SupportLinuxAndWindows()
        {
            FingerprintProvider.SupportedPlatforms.Should().Be(SupportedPlatforms.Windows | SupportedPlatforms.Linux);
        }
    }
}