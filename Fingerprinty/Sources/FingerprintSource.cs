using System;

namespace Fingerprinty.Sources
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class FingerprintSource
    {
        /// <summary>
        /// TODO Docs
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public abstract string Get();
    }
}