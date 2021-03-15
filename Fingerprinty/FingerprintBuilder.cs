using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fingerprinty.Composers;
using Fingerprinty.Sources;

namespace Fingerprinty
{
    /// <summary>
    /// TODO Docs
    /// </summary>
    public class FingerprintBuilder
    {
        private readonly List<FingerprintSource> _sources;
        private readonly FingerprintComposer _composer;

        /// <summary>
        /// TODO Docs
        /// </summary>
        public FingerprintBuilder()
        {
            _sources = new List<FingerprintSource>();
            _composer = null; //TODO default composer
        }

        private FingerprintBuilder(List<FingerprintSource> sources, FingerprintComposer composer)
        {
            _sources = sources;
            _composer = composer;
        }

        /// <summary>
        /// TODO Docs
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public FingerprintBuilder WithSource(FingerprintSource source)
        {
            var newSources = _sources
                .Append(source)
                .ToList();

            return new FingerprintBuilder(newSources, _composer);
        }

        /// <summary>
        /// TODO Docs
        /// </summary>
        /// <param name="composer"></param>
        /// <returns></returns>
        public FingerprintBuilder UsingComposer(FingerprintComposer composer)
        {
            return new FingerprintBuilder(_sources, _composer);
        }

        /// <summary>
        /// TODO Docs
        /// </summary>
        /// <returns></returns>
        public string Build()
        {
            var components = _sources.Select(x => x.Get()).ToList();

            var fingerprint = _composer.Compose(components);

            return fingerprint;
        }

    }
}
