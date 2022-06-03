using AHOY.Assessment.Core.Common;
using Ardalis.GuardClauses;

namespace AHOY.Assessment.Core.Hotels
{
    public class FacilityId : ValueObject
    {
        public Guid Id { get; private set; }

        internal static FacilityId GenerateFacilityId()
        {
            return new FacilityId { Id = Guid.NewGuid() };
        }

        public static FacilityId FromExisting(Guid guid)
        {
            return new FacilityId { Id = Guard.Against.Default(guid) };
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }
    }
}
