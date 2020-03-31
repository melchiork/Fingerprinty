using System;

namespace Fingerprinty
{
    /// <summary>
    /// Calculates <see cref="Fingerprint"/> based on the machine (PC) name.
    /// The machine name can be easily changed by the machine user.
    /// </summary>
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