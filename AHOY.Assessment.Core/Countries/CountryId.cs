using AHOY.Assessment.Core.Common;

namespace AHOY.Assessment.Core.Countries
{
    public class CountryId : ValueObject
    {
        public Guid Id { get; private set; }

        internal static CountryId GenerateNew()
        {
            return new CountryId { Id = Guid.NewGuid() };
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }
    }
}
