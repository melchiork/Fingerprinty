using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Fingerprinty.Composers
{
    /// <summary>
    /// TODO Docs
    /// </summary>
    public abstract class FingerprintComposer
    {
        /// <summary>
        /// TODO Docs
        /// </summary>
        /// <param name="components"></param>
        /// <exception cref="NotImplementedException"></exception>
        [Pure]
        public abstract string Compose(List<string> components);
    }
}