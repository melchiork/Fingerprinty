using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Fingerprinty.HDD;
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
                    typeof(AllDrivesFingerprintProvider),
                    typeof(DriveFingerprintProvider),
                    typeof(IWindowsDriveSerialService),
                    typeof(AllMacAddressesFingerprintProvider),
                    typeof(MachineNameFingerprintProvider),
                    typeof(WindowsProductIdFingerprintProvider),
                    typeof(ProcessorIdFingerprintProvider),
                    typeof(FingerprintProvider),
                    typeof(Fingerprint),
                    typeof(FingerprintProviderFactory),
                    typeof(FingerprintFactory),
                    typeof(SupportedPlatforms)
                });
        }
    }
}