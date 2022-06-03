using AHOY.Assessment.Core.Common;

namespace AHOY.Assessment.Core.Pricing
{
    public class RoomTypePricingId : ValueObject
    {
        public Guid Id { get; private set; }

        internal static RoomTypePricingId GenerateNew()
        {
            return new RoomTypePricingId { Id = Guid.NewGuid() };
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }

    }
}
