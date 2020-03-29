using System;

namespace Fingerprinty
{
    public class MachineNameFingerprintProvider : FingerprintProvider
    {
        public MachineNameFingerprintProvider(HardwareFingerprintFactory fingerprintFactory) : base(fingerprintFactory)
        {
        }

        public override HardwareFingerprint Get()
        {
            var machineName = Environment.MachineName;

            return FingerprintFactory.Create(machineName);
        }

        public override SupportedPlatforms SupportedPlatforms { get; } =
            SupportedPlatforms.Windows | SupportedPlatforms.Linux;
    }
}