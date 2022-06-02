using AHOY.Assessment.Core.Common;
using Ardalis.GuardClauses;

namespace AHOY.Assessment.Core.Reviews
{
    public class ReviewTitle : ValueObject
    {
        public string Title { get; private set; }
        public ReviewTitle(string title)
        {
            Title = Guard.Against.NullOrEmpty(title);
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
