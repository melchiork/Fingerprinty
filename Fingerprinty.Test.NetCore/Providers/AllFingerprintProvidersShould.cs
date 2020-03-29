using FluentAssertions;
using Xunit;

namespace Fingerprinty.Test.NetCore.Providers
{
    public abstract class AllFingerprintProvidersShould
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
        public void ReturnFingerprintWithFixedStringValueLength()
        {
            Skip.If(FingerprintProvider.SupportedPlatforms.IsSupportedOnCurrentRuntime() == false, "Not supported on current OS platform.");

            var fingerprint = FingerprintProvider.Get();

            fingerprint.Value.Should().HaveLength(19);
        }

        [SkippableFact]
        public void ReturnFingerprintMatchingPattern()
        {
            Skip.If(FingerprintProvider.SupportedPlatforms.IsSupportedOnCurrentRuntime() == false, "Not supported on current OS platform.");

            var fingerprint = FingerprintProvider.Get();

            fingerprint.Value.Should().MatchRegex("[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{4}");
        }
    }
}