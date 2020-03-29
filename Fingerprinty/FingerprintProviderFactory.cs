namespace Fingerprinty
{
    public class FingerprintProviderFactory
    {
        public static FingerprintProviderFactory Default { get; } = new FingerprintProviderFactory();
        
        public virtual FingerprintProvider CreateDriveProvider() 
            => new DriveFingerprintProvider(CreateFingerprintFactory());

        public virtual FingerprintProvider CreateMacAddressProvider() 
            => new MacAddressFingerprintProvider(CreateFingerprintFactory());

        public virtual FingerprintProvider CreateMachineNameProvider() 
            => new MachineNameFingerprintProvider(CreateFingerprintFactory());

        public virtual FingerprintProvider CreateWindowsProductIdProvider() 
            => new WindowsProductIdFingerprintProvider(CreateFingerprintFactory());

        private FingerprintFactory CreateFingerprintFactory() => new Sha512FingerprintFactory();
    }
}