using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Fingerprinty.Hardware;
using FluentAssertions;
using FluentAssertions.Types;
using Xunit;

namespace Fingerprinty.Test.NetCore
{
    public class FingerprintyLibraryShould
    {
        [Fact]
        public void ExposeMinimalViableSetOfClasses()
        {
            AllTypes
                .From(Assembly.GetAssembly(typeof(SupportedPlatforms)))
                .Where(type => type.IsPublic)
                .Should()
                .BeEquivalentTo(new List<Type>
                {
                    typeof(DriveFingerprintProvider),
                    typeof(MacAddressFingerprintProvider),
                    typeof(MachineNameFingerprintProvider),
                    typeof(WindowsProductIdFingerprintProvider),
                    typeof(HardwareFingerprintProvider),
                    typeof(HardwareFingerprint),
                    typeof(FingerprintProviderFactory),
                    typeof(SupportedPlatforms),
                });
        }
    }
}