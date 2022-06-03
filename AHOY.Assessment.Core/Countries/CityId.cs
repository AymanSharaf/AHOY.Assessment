using AHOY.Assessment.Core.Common;
using Ardalis.GuardClauses;

namespace AHOY.Assessment.Core.Countries
{
    public class CityId : ValueObject
    {
        public Guid Id { get; private set; }

        internal static CityId GenerateNew()
        {
            return new CityId { Id = Guid.NewGuid() };
        }
        public static CityId FromExisting(Guid guid)
        {
            return new CityId { Id = Guard.Against.Default(guid) };
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }
    }
}
