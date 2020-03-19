using System;
using FluentAssertions;
using Xunit;

namespace Fingerprinty.Test.NetCore
{
    public class HardwareFingerprintShould
    {
        [Fact]
        public void ThrowIfConstructedWithNull()
        {
            Action act = () => { new HardwareFingerprint(null); };

            act.Should().ThrowExactly<ArgumentNullException>();
        }

        [Fact]
        public void ThrowIfConstructedWithValueDisregardingPattern()
        {
            Action act = () => { new HardwareFingerprint("I'm do not conform to the pattern."); };

            act.Should().ThrowExactly<ArgumentException>();
        }
    }
}