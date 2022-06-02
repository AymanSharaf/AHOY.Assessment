using AHOY.Assessment.Core.Common;
using Ardalis.GuardClauses;

namespace AHOY.Assessment.Core.Hotels
{
    public class HotelDescription : ValueObject
    {
        public string Description { get; private set; }

        public HotelDescription(string description)
        {
            Description = Guard.Against.NullOrEmpty(description);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Description;
        }
    }
}
