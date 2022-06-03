using AHOY.Assessment.Core.Common;
using Ardalis.GuardClauses;

namespace AHOY.Assessment.Core.Countries
{
    public class CountryId : ValueObject
    {
        public Guid Id { get; private set; }

        internal static CountryId GenerateNew()
        {
            return new CountryId { Id = Guid.NewGuid() };
        }
        public static CountryId FromExisting(Guid guid)
        {
            return new CountryId { Id = Guard.Against.Default(guid) };
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }
    }
}
