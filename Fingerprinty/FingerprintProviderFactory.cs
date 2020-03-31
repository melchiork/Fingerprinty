using Fingerprinty.HDD;

namespace Fingerprinty
{
    public class FingerprintProviderFactory
    {
        public static FingerprintProviderFactory Default { get; } 
            = new FingerprintProviderFactory();

        public virtual AllDrivesFingerprintProvider CreateAllDrivesFingerprintProvider()
            => new AllDrivesFingerprintProvider(CreateSha512FingerprintFactory(), new WindowsDriveSerialService());

        public virtual DriveFingerprintProvider CreateDriveProvider() 
            => new DriveFingerprintProvider(CreateSha512FingerprintFactory(), new WindowsDriveSerialService());

        public virtual AllMacAddressesFingerprintProvider CreateMacAddressProvider() 
            => new AllMacAddressesFingerprintProvider(CreateSha512FingerprintFactory());

        public virtual MachineNameFingerprintProvider CreateMachineNameProvider() 
            => new MachineNameFingerprintProvider(CreateSha512FingerprintFactory());

        public virtual WindowsProductIdFingerprintProvider CreateWindowsProductIdProvider() 
            => new WindowsProductIdFingerprintProvider(CreateSha512FingerprintFactory());

        private static FingerprintFactory CreateSha512FingerprintFactory() 
            => new Sha512FingerprintFactory();
    }
}