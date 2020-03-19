using System;
using System.Runtime.InteropServices;

namespace Fingerprinty
{
    [Flags]
    public enum SupportedPlatforms
    {
        Windows = 1,
        Linux = 2
    }

    public static class SupportedPlatformsExtensions
    {
        public static bool IsSupportedOnCurrentRuntime(this SupportedPlatforms supportedPlatforms)
        {
            if (supportedPlatforms.HasFlag(SupportedPlatforms.Windows) &&
                RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return true;
            }

            if (supportedPlatforms.HasFlag(SupportedPlatforms.Linux) &&
                RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return true;
            }

            return false;
        }
    }
}