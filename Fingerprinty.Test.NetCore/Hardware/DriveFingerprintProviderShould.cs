using Fingerprinty.Hardware;

namespace Fingerprinty.Test.NetCore.Hardware
{
    public class DriveFingerprintProviderShould : AllHardwareProvidersShould
    {
        protected override HardwareFingerprintProvider FingerprintProvider { get; } = new DriveFingerprintProvider();
    }
}