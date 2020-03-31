using System;
using System.Text.RegularExpressions;

namespace Fingerprinty
{
    public class Fingerprint : IEquatable<Fingerprint>
    {
        public static Regex Pattern { get; } = new Regex("[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{4}",
            RegexOptions.CultureInvariant | RegexOptions.Compiled);

        internal Fingerprint(string value) 
            : this(value, x => Pattern.IsMatch(x))
        {
            
        }

        protected Fingerprint(string value, Func<string, bool> isValid)
        {
            if (isValid(value) == false)
            {
                throw new ArgumentException("Provided value doesn't match the pattern.", nameof(value));
            }

            Value = value;
        }
        
        /// <summary>
        /// Human readable value of <see cref="Fingerprint"/>
        /// </summary>
        public string Value { get; }

        public override string ToString() => Value;

        public virtual bool Equals(Fingerprint other)
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
            return Equals((Fingerprint) obj);
        }

        public override int GetHashCode()
        {
            return Value != null ? Value.GetHashCode() : 0;
        }
    }
}