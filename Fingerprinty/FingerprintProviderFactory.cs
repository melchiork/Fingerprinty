using Fingerprinty.HDD;

namespace Fingerprinty
{
    /// <summary>
    /// Factory that allows of parameters-less creation of various different <seealso cref="FingerprintProvider"/> implementations.
    /// </summary>
    public class FingerprintProviderFactory
    {
        /// <summary>
        /// Default instance of the factory. A singleton.
        /// </summary>
        public static FingerprintProviderFactory Default { get; } 
            = new FingerprintProviderFactory();

        /// <summary>
        /// Creates new instance of <see cref="AllDrivesFingerprintProvider"/>.
        /// </summary>
        public virtual AllDrivesFingerprintProvider CreateAllDrivesProvider()
            => new AllDrivesFingerprintProvider(CreateSha512FingerprintFactory(), new WindowsDriveSerialService());

        /// <summary>
        /// Creates new instance of <see cref="DriveFingerprintProvider"/>.
        /// </summary>
        public virtual DriveFingerprintProvider CreateDriveProvider() 
            => new DriveFingerprintProvider(CreateSha512FingerprintFactory(), new WindowsDriveSerialService());

        /// <summary>
        /// Creates new instance of <see cref="AllMacAddressesFingerprintProvider"/>.
        /// </summary>
        public virtual AllMacAddressesFingerprintProvider CreateAllMacAddressesProvider() 
            => new AllMacAddressesFingerprintProvider(CreateSha512FingerprintFactory());

        /// <summary>
        /// Creates new instance of <see cref="MachineNameFingerprintProvider"/>.
        /// </summary>
        public virtual MachineNameFingerprintProvider CreateMachineNameProvider() 
            => new MachineNameFingerprintProvider(CreateSha512FingerprintFactory());

        /// <summary>
        /// Creates new instance of <see cref="WindowsProductIdFingerprintProvider"/>.
        /// </summary>
        public virtual WindowsProductIdFingerprintProvider CreateWindowsProductIdProvider() 
            => new WindowsProductIdFingerprintProvider(CreateSha512FingerprintFactory());

        /// <summary>
        /// Creates new instance of <see cref="ProcessorIdFingerprintProvider"/>.
        /// </summary>
        public ProcessorIdFingerprintProvider CreateProcessorIdProvider()
            => new ProcessorIdFingerprintProvider(CreateSha512FingerprintFactory());

        /// <summary>
        /// Creates new instance of <see cref="MotherboardFingerprintProvider"/>.
        /// </summary>
        public MotherboardFingerprintProvider CreateMotherboardProvider()
         => new MotherboardFingerprintProvider(CreateSha512FingerprintFactory());

        private static FingerprintFactory CreateSha512FingerprintFactory() 
            => new Sha512FingerprintFactory();
    }
}