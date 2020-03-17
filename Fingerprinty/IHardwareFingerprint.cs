using System;

namespace Fingerprinty
{
    public interface IHardwareFingerprint : IEquatable<IHardwareFingerprint>
    {
        string Value { get; }
    }
}