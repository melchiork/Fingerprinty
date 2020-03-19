using System;

namespace Fingerprinty.Hardware
{
    public class MachineNameFingerprintProvider : HardwareFingerprintProvider
    {
        public override HardwareFingerprint Get()
        {
            var machineName = Environment.MachineName;

            return FingerprintFactory.Create(machineName);
        }

        public override SupportedPlatforms SupportedPlatforms { get; } =
            SupportedPlatforms.Windows | SupportedPlatforms.Linux;
    }
}