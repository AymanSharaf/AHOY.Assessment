using AHOY.Assessment.Core.Common;
using Ardalis.GuardClauses;

namespace AHOY.Assessment.Core.Countries
{
    public class Name : ValueObject
    {
        public string Value { get; private set; }
        public Name(string value)
        {
            Guard.Against.NullOrEmpty(value, "Name connot be null or empty");
            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
