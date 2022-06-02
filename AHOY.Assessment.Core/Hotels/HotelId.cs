using AHOY.Assessment.Core.Common;

namespace AHOY.Assessment.Core.Hotels
{
    public class HotelId : ValueObject
    {
        public Guid Id { get; private set; }

        internal static HotelId GenerateHotelId()
        {
            return new HotelId { Id = Guid.NewGuid() };
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }
    }
}
