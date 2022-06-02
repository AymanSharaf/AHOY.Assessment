using AHOY.Assessment.Core.Common;
using Ardalis.GuardClauses;

namespace AHOY.Assessment.Core.Hotels
{
    public class FacilityName : ValueObject
    {
        public string Name { get; private set; }

        public FacilityName(string name)
        {
            Guard.Against.NullOrEmpty(name, "Facility name cannot be empty");

            Name = name;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }
    }
}
