using Fingerprinty.Providers;
using FluentAssertions;
using Xunit;

namespace Fingerprinty.Test.NetCore.Providers
{
    public class HardwareFingerprintProviderShould
    {
        private readonly IFingerprintProvider _fingerprintProvider;

        public HardwareFingerprintProviderShould()
        {
            _fingerprintProvider = new HardwareFingerprintProvider();
        }

        [Fact]
        public void ReturnTheSameValueIfCalledTwice()
        {
            var first = _fingerprintProvider.Get();

            var second = _fingerprintProvider.Get();

            first.Should().BeEquivalentTo(second);
        }
    }
}