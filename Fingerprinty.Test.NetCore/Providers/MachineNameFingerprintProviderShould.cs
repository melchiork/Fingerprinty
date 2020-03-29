using FluentAssertions;
using Xunit;

namespace Fingerprinty.Test.NetCore.Providers
{
    public class MachineNameFingerprintProviderShould : AllFingerprintProvidersShould
    {
        protected override FingerprintProvider FingerprintProvider { get; } 
            = FingerprintProviderFactory.Default.CreateMachineNameProvider();

        [Fact]
        public void SupportLinuxAndWindows()
        {
            FingerprintProvider.SupportedPlatforms.Should().Be(SupportedPlatforms.Windows | SupportedPlatforms.Linux);
        }
    }
}