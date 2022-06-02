using AHOY.Assessment.Core.Common;

namespace AHOY.Assessment.Core.Countries
{
    public class CityId : ValueObject
    {
        public Guid Id { get; private set; }

        internal static CityId GenerateNew()
        {
            return new CityId { Id = Guid.NewGuid() };
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }
    }
}
