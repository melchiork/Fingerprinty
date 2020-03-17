using Fingerprinty.Hardware;
using FluentAssertions;
using Xunit;

namespace Fingerprinty.Test.NetCore.Hardware
{
    public abstract class AllHardwareProvidersShould
    {
        protected abstract HardwareFingerprintProvider FingerprintProvider { get; }

        [SkippableFact]
        public void ReturnTheSameValueIfCalledTwice()
        {
            Skip.If(FingerprintProvider.SupportedPlatforms.IsSupportedOnCurrentRuntime() == false, "Not supported on current OS platform.");

            var first = FingerprintProvider.Get();

            var second = FingerprintProvider.Get();

            first.Should().BeEquivalentTo(second);
        }
    }
}