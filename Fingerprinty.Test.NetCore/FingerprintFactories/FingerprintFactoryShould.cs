using System;
using FluentAssertions;
using Xunit;

namespace Fingerprinty.Test.NetCore.FingerprintFactories
{
    public class FingerprintFactoryShould
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void NotAcceptInvalidTextInput(string input)
        {
            var factory = new ConcreteFingerprintFactory();

            Action act = () => factory.Create(input);

            act.Should().ThrowExactly<ArgumentException>();
        }

        [Fact]
        public void CallCreationFromBytesInternally()
        {
            var factory = new ConcreteFingerprintFactory();

            factory.Create("some_text");

            factory.TimesCreateFromBytesWasCalled.Should().Be(1);
        }

        private class ConcreteFingerprintFactory : FingerprintFactory
        {
            public int TimesCreateFromBytesWasCalled { get; private set; }

            public override Fingerprint Create(byte[] bytes)
            {
                TimesCreateFromBytesWasCalled++;
                return null;
            }
        }
    }
}