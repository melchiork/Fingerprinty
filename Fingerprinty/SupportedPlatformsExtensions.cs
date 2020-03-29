using System.Runtime.InteropServices;

namespace Fingerprinty
{
    internal static class SupportedPlatformsExtensions
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