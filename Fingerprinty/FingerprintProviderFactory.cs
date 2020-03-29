using Fingerprinty.Hardware;

namespace Fingerprinty
{
    public class FingerprintProviderFactory
    {
        public static FingerprintProviderFactory Default { get; } = new FingerprintProviderFactory();

        public virtual HardwareFingerprintProvider CreateDriveProvider() => new DriveFingerprintProvider();
        public virtual HardwareFingerprintProvider CreateMacAddressProvider() => new MacAddressFingerprintProvider();
        public virtual HardwareFingerprintProvider CreateMachineNameProvider() => new MachineNameFingerprintProvider();
        public virtual HardwareFingerprintProvider CreateWindowsProductIdProvider() => new WindowsProductIdFingerprintProvider();
    }
}