using AHOY.Assessment.Core.Common;

namespace AHOY.Assessment.Core.Reviews
{
    public class ReviewId : ValueObject
    {
        public Guid Id { get; private set; }

        internal static ReviewId GenerateNew()
        {
            return new ReviewId { Id = Guid.NewGuid() };
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }
    }
}
