namespace Fingerprinty
{
    /// <summary>
    /// Base for all classes that provide fingerprints.
    /// </summary>
    public abstract class FingerprintProvider
    {
        /// <summary>
        /// Instance of <see cref="FingerprintFactory"/> that us sued to provide normalized fingerprints from arbitrary data.
        /// </summary>
        protected internal readonly FingerprintFactory FingerprintFactory;

        /// <summary>
        /// Creates new instance of <seealso cref="FingerprintProvider"/>.
        /// </summary>
        /// <param name="fingerprintFactory"></param>
        protected FingerprintProvider(FingerprintFactory fingerprintFactory)
        {
            FingerprintFactory = fingerprintFactory;
        }

        /// <summary>
        /// Get new fingerprint based on concrete implementation.
        /// </summary>
        /// <returns>A <see cref="Fingerprint"/></returns>
        public abstract Fingerprint Get();

        /// <summary>
        /// THe platforms on which given <see cref="FingerprintProvider"/> works and has been tested.
        /// </summary>
        public abstract SupportedPlatforms SupportedPlatforms { get; }
    }
}