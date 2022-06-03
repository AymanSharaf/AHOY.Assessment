using AHOY.Assessment.Core.Hotels;

namespace AHOY.Assessment.Core.Pricing
{
    public class RoomTypeDiscount
    {
        public RoomTypeDiscountId Id { get; private set; }
        public RoomType RoomType { get; private set; }
        public Price Discount { get; private set; }

        private RoomTypeDiscount()
        {

        }

        internal RoomTypeDiscount(RoomType roomType, decimal amount, string currency)
        {
            Id = RoomTypeDiscountId.GenerateNew();
            RoomType = roomType;
            Discount = new Price(amount, currency);
        }
    }
}
