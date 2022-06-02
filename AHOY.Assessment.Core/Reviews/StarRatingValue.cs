using AHOY.Assessment.Core.Common;
using Ardalis.GuardClauses;

namespace AHOY.Assessment.Core.Reviews
{
    public class StarRatingValue : ValueObject
    {
        public short Value { get; private set; }

        public StarRatingValue(short value)
        {
            Value = Guard.Against.OutOfRange<short>(value, nameof(value), 1, 5);
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
