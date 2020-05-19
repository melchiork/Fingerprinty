using Fingerprinty.HDD;

namespace Fingerprinty
{
    /// <summary>
    /// Factory that allows of parameters-less creation of various different <seealso cref="FingerprintProvider"/> implementations.
    /// </summary>
    public class FingerprintProviderFactory
    {
        /// <summary>
        /// Default instance of the factory.
        /// </summary>
        public static FingerprintProviderFactory Default { get; } 
            = new FingerprintProviderFactory();

        /// <summary>
        /// 
        /// </summary>
        public virtual AllDrivesFingerprintProvider CreateAllDrivesProvider()
            => new AllDrivesFingerprintProvider(CreateSha512FingerprintFactory(), new WindowsDriveSerialService());

        /// <summary>
        /// 
        /// </summary>
        public virtual DriveFingerprintProvider CreateDriveProvider() 
            => new DriveFingerprintProvider(CreateSha512FingerprintFactory(), new WindowsDriveSerialService());

        /// <summary>
        /// 
        /// </summary>
        public virtual AllMacAddressesFingerprintProvider CreateAllMacAddressesProvider() 
            => new AllMacAddressesFingerprintProvider(CreateSha512FingerprintFactory());

        /// <summary>
        /// 
        /// </summary>
        public virtual MachineNameFingerprintProvider CreateMachineNameProvider() 
            => new MachineNameFingerprintProvider(CreateSha512FingerprintFactory());

        /// <summary>
        /// 
        /// </summary>
        public virtual WindowsProductIdFingerprintProvider CreateWindowsProductIdProvider() 
            => new WindowsProductIdFingerprintProvider(CreateSha512FingerprintFactory());

        /// <summary>
        /// 
        /// </summary>
        public ProcessorIdFingerprintProvider CreateProcessorIdProvider()
            => new ProcessorIdFingerprintProvider(CreateSha512FingerprintFactory());

        /// <summary>
        /// 
        /// </summary>
        public MotherboardFingerprintProvider CreateMotherboardProvider()
         => new MotherboardFingerprintProvider(CreateSha512FingerprintFactory());

        private static FingerprintFactory CreateSha512FingerprintFactory() 
            => new Sha512FingerprintFactory();
    }
}