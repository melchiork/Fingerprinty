using FluentAssertions;
using Xunit;

namespace Fingerprinty.Test.NetCore.Hardware
{
    public abstract class AllHardwareProvidersShould
    {
        protected abstract IHardwareFingerprintProvider FingerprintProvider { get; }

        [Fact]
        public void ReturnTheSameValueIfCalledTwice()
        {
            var first = FingerprintProvider.Get();

            var second = FingerprintProvider.Get();

            first.Should().BeEquivalentTo(second);
        }
    }
}