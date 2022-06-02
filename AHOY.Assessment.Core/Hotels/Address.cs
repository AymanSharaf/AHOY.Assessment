using AHOY.Assessment.Core.Common;
using Ardalis.GuardClauses;

namespace AHOY.Assessment.Core.Hotels
{
    public class Address : ValueObject
    {
        public string Value { get; private set; }

        internal static Address CreateNew(string value)
        {
            return new Address { Value = Guard.Against.NullOrEmpty(value, "Address Value cannot be empty") };
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
