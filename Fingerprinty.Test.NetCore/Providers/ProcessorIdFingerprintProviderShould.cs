using FluentAssertions;
using Xunit;

namespace Fingerprinty.Test.NetCore.Providers
{
    public class ProcessorIdFingerprintProviderShould : AllFingerprintProvidersShould
    {
        protected override FingerprintProvider FingerprintProvider { get; } =
            FingerprintProviderFactory.Default.CreateProcessorIdFingerprintProvider();

        [Fact]
        public void SupportOnlyWindows()
        {
            FingerprintProvider.SupportedPlatforms.Should().Be(SupportedPlatforms.Windows);
        }
    }
}