using AHOY.Assessment.Core.Common;

namespace AHOY.Assessment.Core.Reviews
{
    public class StarRatingId : ValueObject
    {
        public Guid Id { get; private set; }

        internal static StarRatingId GenerateNew()
        {
            return new StarRatingId { Id = Guid.NewGuid() };
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }

    }
}
