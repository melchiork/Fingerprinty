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
            Skip.IfPlatformIsNotSupported(FingerprintProvider);

            var first = FingerprintProvider.Get();

            var second = FingerprintProvider.Get();

            first.Should().BeEquivalentTo(second);
        }

        [SkippableFact]
        public void ReturnFingerprintWithFixedStringValueLength()
        {
            Skip.IfPlatformIsNotSupported(FingerprintProvider);

            var fingerprint = FingerprintProvider.Get();

            fingerprint.Should().NotBeNull();
            fingerprint.Value.Should().HaveLength(19);
        }

        [SkippableFact]
        public void ReturnFingerprintMatchingPattern()
        {
            Skip.IfPlatformIsNotSupported(FingerprintProvider);

            var fingerprint = FingerprintProvider.Get();

            fingerprint.Should().NotBeNull();
            fingerprint.Value.Should().MatchRegex("[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{4}");
        }
    }
}