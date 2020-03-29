using FluentAssertions;
using Xunit;

namespace Fingerprinty.Test.NetCore.Providers
{
    public abstract class AllHardwareProvidersShould
    {
        protected abstract FingerprintProvider FingerprintProvider { get; }

        [SkippableFact]
        public void ReturnTheSameValueIfCalledTwice()
        {
            Skip.If(FingerprintProvider.SupportedPlatforms.IsSupportedOnCurrentRuntime() == false, "Not supported on current OS platform.");

            var first = FingerprintProvider.Get();

            var second = FingerprintProvider.Get();

            first.Should().BeEquivalentTo(second);
        }

        [SkippableFact]
        public void ReturnHardwareFingerprintWithFixedStringValueLength()
        {
            Skip.If(FingerprintProvider.SupportedPlatforms.IsSupportedOnCurrentRuntime() == false, "Not supported on current OS platform.");

            var hardwareFingerprint = FingerprintProvider.Get();

            hardwareFingerprint.Value.Should().HaveLength(19);
        }

        [SkippableFact]
        public void ReturnHardwareFingerprintMAtchingPattern()
        {
            Skip.If(FingerprintProvider.SupportedPlatforms.IsSupportedOnCurrentRuntime() == false, "Not supported on current OS platform.");

            var hardwareFingerprint = FingerprintProvider.Get();

            hardwareFingerprint.Value.Should().MatchRegex("[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{4}");
        }
    }
}