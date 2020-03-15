namespace Fingerprinty
{
    public interface IHardwareFingerprintProvider
    {
        string Get();

        SupportedPlatforms SupportedPlatforms { get; }
    }
}