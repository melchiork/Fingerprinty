using System;
using System.Linq;
using System.Management;

namespace Fingerprinty
{
    /// <summary>
    /// Calculates <see cref="Fingerprint"/> based on the Processor Id.
    /// </summary>
    public class ProcessorIdFingerprintProvider : FingerprintProvider
    {
        /// <inheritdoc />
        public ProcessorIdFingerprintProvider(FingerprintFactory fingerprintFactory) : base(fingerprintFactory)
        {
        }

        /// <inheritdoc />
        public override Fingerprint Get()
        {
            try
            {
                var managementObjectSearcher = new ManagementObjectSearcher("SELECT ProcessorId FROM Win32_Processor");
                var managementObjectsFound = managementObjectSearcher.Get();

                var processorsIds = managementObjectsFound
                    .Cast<ManagementObject>()
                    .Select(x => (string)x["ProcessorId"])
                    .OrderBy(x => x)
                    .ToList();

                var joinedProcessorIds = string.Join(string.Empty, processorsIds);

                var fingerprint = FingerprintFactory.Create(joinedProcessorIds);

                return fingerprint;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Unable to calculate fingerprint based on ProcessorId.", ex);
            }
        }

        /// <inheritdoc />
        public override SupportedPlatforms SupportedPlatforms { get; } = SupportedPlatforms.Windows;
    }
}
