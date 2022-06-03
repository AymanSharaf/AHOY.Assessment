using AHOY.Assessment.Core.Hotels;

namespace AHOY.Assessment.Core.Pricing
{
    public class HotelPricing
    {
        public HotelPricingId Id { get; private set; }
        public HotelId HotelId { get; private set; }

        private List<RoomTypePricing> _roomTypePricings;
        public IReadOnlyList<RoomTypePricing> RoomTypePricings => _roomTypePricings;

        private List<RoomTypeDiscount> _roomTypeDiscounts;
        public IReadOnlyList<RoomTypeDiscount> RoomTypeDiscounts => _roomTypeDiscounts;

        private HotelPricing()
        {

        }

        public static HotelPricing CreateNew(HotelId hotelId)
        {
            return new HotelPricing
            {
                Id = HotelPricingId.GenerateNew(),
                HotelId = hotelId,
                _roomTypePricings = new List<RoomTypePricing>(),
                _roomTypeDiscounts = new List<RoomTypeDiscount>()
            };
        }

        public void AddRoomTypePricing(RoomType roomType, decimal amount, string currency)
        {
            if (_roomTypePricings.Any(p => p.RoomType.Equals(roomType)))
            {
                throw new InvalidOperationException("This room type has a pricing already");
            }

            _roomTypePricings.Add(new RoomTypePricing(roomType, amount, currency));
        }
        public void AddRoomTypeDiscount(RoomType roomType, decimal amount, string currency)
        {
            // To be Implemented
        }
    }
}
