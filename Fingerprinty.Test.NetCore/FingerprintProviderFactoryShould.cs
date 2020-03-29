using FluentAssertions;
using Xunit;

namespace Fingerprinty.Test.NetCore
{
    public class FingerprintProviderFactoryShould
    {
        [Fact]
        public void HaveStaticDefaultProperty()
        {
            typeof(FingerprintProviderFactory)
                .Should()
                .HaveProperty<FingerprintProviderFactory>("Default")
                .Which.GetMethod.IsStatic.Should().BeTrue();
        }
    }
}