using AHOY.Assessment.Core.Hotels;

namespace AHOY.Assessment.Core.Pricing
{
    public class RoomTypePricing
    {
        public RoomTypePricingId Id { get; private set; }
        public RoomType RoomType { get; private set; }
        public Price Price { get; private set; }

        private RoomTypePricing()
        {

        }

        internal RoomTypePricing(RoomType roomType, decimal amount, string currency)
        {
            Id = RoomTypePricingId.GenerateNew();
            RoomType = roomType;
            Price = new Price(amount, currency);
        }
    }
}
