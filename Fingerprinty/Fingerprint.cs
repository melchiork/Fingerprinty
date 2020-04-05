using System;
using System.Text.RegularExpressions;

namespace Fingerprinty
{
    /// <summary>
    /// Potentially unique fingerprint of a machine.
    /// </summary>
    public class Fingerprint : IEquatable<Fingerprint>
    {
        /// <summary>
        /// Pattern used for fingerprint generation. E.g. ab12-ca9a-5f00-d12d
        /// </summary>
        public static Regex Pattern { get; } = new Regex("[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{4}",
            RegexOptions.CultureInvariant | RegexOptions.Compiled);

        /// <summary>
        /// Default constructor, validates the value against the <see cref="Pattern"/>.
        /// </summary>
        /// <param name="value"></param>
        internal Fingerprint(string value) 
            : this(value, x => Pattern.IsMatch(x))
        {
            
        }

        /// <summary>
        /// Constructor, validates the value against arbitrary function.
        /// </summary>
        /// <param name="value">Value of a fingerprint.</param>
        /// <param name="isValid">Method run to check if the value provided matches the fingerprint "shape".</param>
        /// <exception cref="ArgumentException">Thrown when the values doesn't match isValid.</exception>
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns><see cref="string"/> representation fo the <see cref="Fingerprint"/>.</returns>
        public override string ToString() => Value;

        /// <inheritdoc cref="IEquatable{T}.Equals(T)"/>
        public virtual bool Equals(Fingerprint other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value == other.Value;
        }

        /// <inheritdoc cref="object.Equals(object)"/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Fingerprint) obj);
        }

        /// <summary>
        /// Calculates hash code.
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            return Value != null ? Value.GetHashCode() : 0;
        }
    }
}