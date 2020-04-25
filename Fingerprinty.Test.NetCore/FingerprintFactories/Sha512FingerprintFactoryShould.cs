using System;
using System.Linq;
using System.Text;
using FluentAssertions;
using Xunit;

namespace Fingerprinty.Test.NetCore.FingerprintFactories
{
    public class Sha512FingerprintFactoryShould
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void NotAcceptInvalidTextInput(string input)
        {
            var factory = CreateSut();

            Action act = () => factory.Create(input);

            act.Should().ThrowExactly<ArgumentException>();
        }

        [Fact]
        public void ReturnTheSameValueForTheSameInput()
        {
            const string input = "fingerprinty";

            var factory = CreateSut();

            var firstResult = factory.Create(input);
            var secondResult = factory.Create(input);

            firstResult.Should().BeEquivalentTo(secondResult);
        }

        [Theory]
        [InlineData("some_input", "0095-72ee-0752-f32c")]
        [InlineData("123", "3c99-09af-ec25-354d")]
        [InlineData("SERIAL_VALUE", "fdc5-943a-5afd-18e0")]
        public void ReturnExpectedValueForKnownInput(string input, string expectedOutput)
        {
            var factory = CreateSut();

            var result = factory.Create(input);

            result.Value.Should().Be(expectedOutput);
        }

        [Fact]
        public void ReturnTheSameValueForEncodedTextAsForText()
        {
            const string textInput = "some input for calculation";
            var bytesInput = Encoding.UTF8.GetBytes(textInput);

            var factory = CreateSut();

            var textResult = factory.Create(textInput);
            var bytesResult = factory.Create(bytesInput);

            textResult.Should().BeEquivalentTo(bytesResult);
        }

        [Fact]
        public void ShouldReturnReasonablyUniqueValues()
        {
            var factory = CreateSut();

            var results =
                Enumerable.Range(0, 100000)
                    .Select(x => Guid.NewGuid().ToString())
                    .Select(factory.Create);

            results.Should().OnlyHaveUniqueItems();
        }

        [Fact]
        public void CallCreationFromBytesInternally()
        {
            var factory = new Sha512FingerprintFactoryMock();

            factory.Create("some_text");

            factory.GetType().Should().BeDerivedFrom<Sha512FingerprintFactory>();
            factory.TimesCreateFromBytesWasCalled.Should().Be(1);
        }

        private static Sha512FingerprintFactory CreateSut()
        {
            return new Sha512FingerprintFactory();
        }

        private class Sha512FingerprintFactoryMock : Sha512FingerprintFactory
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