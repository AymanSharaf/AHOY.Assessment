using AHOY.Assessment.Core.Common;

namespace AHOY.Assessment.Core.Pricing
{
    public class RoomTypeDiscountId : ValueObject
    {
        public Guid Id { get; private set; }

        internal static RoomTypeDiscountId GenerateNew()
        {
            return new RoomTypeDiscountId { Id = Guid.NewGuid() };
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }
    }
}
