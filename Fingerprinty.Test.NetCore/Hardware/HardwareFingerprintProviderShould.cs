using Fingerprinty.Hardware;

namespace Fingerprinty.Test.NetCore.Hardware
{
    public class HardwareFingerprintProviderShould : AllHardwareProvidersShould
    {
        protected override IHardwareFingerprintProvider FingerprintProvider { get; } = new WindowsProductIdFingerprint();
    }
}