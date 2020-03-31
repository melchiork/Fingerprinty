namespace Fingerprinty.Test.NetCore
{
    public class Skip
    {
        public static void IfPlatformIsNotSupported(FingerprintProvider provider)
        {
            Xunit.Skip.If(
                provider.SupportedPlatforms.IsSupportedOnCurrentRuntime() == false,
                "Not supported on current OS platform.");
        }
    }
}