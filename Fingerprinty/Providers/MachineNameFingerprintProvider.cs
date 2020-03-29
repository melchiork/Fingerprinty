using System;

namespace Fingerprinty
{
    public class MachineNameFingerprintProvider : FingerprintProvider
    {
        public MachineNameFingerprintProvider(FingerprintFactory fingerprintFactory) : base(fingerprintFactory)
        {
        }

        public override Fingerprint Get()
        {
            var machineName = Environment.MachineName;

            return FingerprintFactory.Create(machineName);
        }

        public override SupportedPlatforms SupportedPlatforms { get; } =
            SupportedPlatforms.Windows | SupportedPlatforms.Linux;
    }
}