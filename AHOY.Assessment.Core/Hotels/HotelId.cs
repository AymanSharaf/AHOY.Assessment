using AHOY.Assessment.Core.Common;
using Ardalis.GuardClauses;

namespace AHOY.Assessment.Core.Hotels
{
    public class HotelId : ValueObject
    {
        public Guid Id { get; private set; }

        internal static HotelId GenerateHotelId()
        {
            return new HotelId { Id = Guid.NewGuid() };
        }

        public static HotelId FromExisting(Guid guid)
        {
            return new HotelId { Id = Guard.Against.Default(guid) };
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }
    }
}
