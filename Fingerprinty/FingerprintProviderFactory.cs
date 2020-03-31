using Fingerprinty.HDD;

namespace Fingerprinty
{
    public class FingerprintProviderFactory
    {
        public static FingerprintProviderFactory Default { get; } 
            = new FingerprintProviderFactory();

        public virtual FingerprintProvider CreateAllDrivesFingerprintProvider()
            => new AllDrivesFingerprintProvider(CreateFingerprintFactory(), new WindowsDriveSerialService());

        public virtual FingerprintProvider CreateDriveProvider() 
            => new DriveFingerprintProvider(CreateFingerprintFactory(), new WindowsDriveSerialService());

        public virtual FingerprintProvider CreateMacAddressProvider() 
            => new AllMacAddressesFingerprintProvider(CreateFingerprintFactory());

        public virtual FingerprintProvider CreateMachineNameProvider() 
            => new MachineNameFingerprintProvider(CreateFingerprintFactory());

        public virtual FingerprintProvider CreateWindowsProductIdProvider() 
            => new WindowsProductIdFingerprintProvider(CreateFingerprintFactory());

        private static FingerprintFactory CreateFingerprintFactory() 
            => new Sha512FingerprintFactory();
    }
}