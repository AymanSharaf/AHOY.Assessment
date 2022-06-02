using AHOY.Assessment.Core.Common;
using Ardalis.GuardClauses;

namespace AHOY.Assessment.Core.Hotels
{
    public class HotelName : ValueObject
    {
        public string Name { get; private set; }

        public HotelName(string name)
        {
            Guard.Against.NullOrEmpty(name, "Hotel name cannot be empty");

            Name = name;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }
    }
}
