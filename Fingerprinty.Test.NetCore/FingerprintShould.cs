using System;
using FluentAssertions;
using Xunit;

namespace Fingerprinty.Test.NetCore
{
    public class FingerprintShould
    {
        [Fact]
        public void ThrowIfConstructedWithNull()
        {
            Action act = () => { new Fingerprint(null); };

            act.Should().ThrowExactly<ArgumentNullException>();
        }

        [Fact]
        public void ThrowIfConstructedWithValueDisregardingPattern()
        {
            Action act = () => { new Fingerprint("I'm do not conform to the pattern."); };

            act.Should().ThrowExactly<ArgumentException>();
        }

        [Fact]
        public void ImplementIEquatableOfItself()
        {
            typeof(Fingerprint)
                .Should()
                .Implement<IEquatable<Fingerprint>>();
        }

        [Fact]
        public void BeEquatableToItself()
        {
            var first = new Fingerprint("1234-1234-1234-1234");

            var second = new Fingerprint("1234-1234-1234-1234");

            first.Equals(second).Should().BeTrue();
        }

        [Fact]
        public void HaveProtectedConstructorWithValidation()
        {
            typeof(Fingerprint)
                .Should()
                .HaveConstructor(new [] {typeof(string), typeof(Func<string, bool>)})
                .Which
                .IsFamily.Should().BeTrue();
        }

        [Fact]
        public void ShouldAllowDerivedClassesWithArbitraryValidation()
        {
            var derived = new DerivedFingerprint("not_matching+default-pattern");

            derived.Should().NotBeNull();
            derived.Value.Should().Be("not_matching+default-pattern");
        }

        private class DerivedFingerprint : Fingerprint
        {
            public DerivedFingerprint(string value) : base(value, x => true)
            {
            }
        }
    }
}