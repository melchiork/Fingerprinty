using System;

namespace Fingerprinty
{
    /// <summary>
    /// Calculates <see cref="Fingerprint"/> based on the machine (PC) name.
    /// The machine name can be easily changed by the machine user.
    /// </summary>
    public class MachineNameFingerprintProvider : FingerprintProvider
    {
        /// <inheritdoc />
        public MachineNameFingerprintProvider(FingerprintFactory fingerprintFactory) : base(fingerprintFactory)
        {
        }

        /// <inheritdoc />
        public override Fingerprint Get()
        {
            var machineName = Environment.MachineName;

            return FingerprintFactory.Create(machineName);
        }

        /// <inheritdoc />
        public override SupportedPlatforms SupportedPlatforms { get; } =
            SupportedPlatforms.Windows | SupportedPlatforms.Linux;
    }
}