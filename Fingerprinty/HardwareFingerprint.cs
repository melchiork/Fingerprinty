using System;

namespace Fingerprinty
{
    public class HardwareFingerprint : IEquatable<HardwareFingerprint>
    {
        public static int ValueLength { get; } = 16;

        protected internal HardwareFingerprint(string value)
        {
            Value = value;
        }
        
        /// <summary>
        /// Human readable value of <see cref="HardwareFingerprint"/>
        /// </summary>
        public virtual string Value { get; }

        public virtual bool Equals(HardwareFingerprint other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((HardwareFingerprint) obj);
        }

        public override int GetHashCode()
        {
            return Value != null ? Value.GetHashCode() : 0;
        }
    }
}