using AHOY.Assessment.Core.Common;
using Ardalis.GuardClauses;

namespace AHOY.Assessment.Core.Reviews
{
    public class ReviewDetails : ValueObject
    {
        public string Details { get; private set; }
        public ReviewDetails(string details)
        {
            Details = Guard.Against.NullOrEmpty(details);
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Details;
        }
    }
}
