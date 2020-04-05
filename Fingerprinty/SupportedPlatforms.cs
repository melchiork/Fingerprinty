using System;

namespace Fingerprinty
{
    /// <summary>
    /// Platform(s) on which given <seealso cref="FingerprintProvider"/> is supported.
    /// </summary>
    [Flags]
    public enum SupportedPlatforms
    {
        /// <summary>
        /// 
        /// </summary>
        Windows = 1,
        
        /// <summary>
        /// 
        /// </summary>
        Linux = 2,
    }
}