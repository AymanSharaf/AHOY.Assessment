using AHOY.Assessment.Core.Common;

namespace AHOY.Assessment.Core.Hotels
{
    public class FacilityId : ValueObject
    {
        public Guid Id { get; private set; }

        internal static FacilityId GenerateFacilityId()
        {
            return new FacilityId { Id = Guid.NewGuid() };
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }
    }
}
