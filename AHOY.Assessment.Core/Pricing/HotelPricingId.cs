using AHOY.Assessment.Core.Common;

namespace AHOY.Assessment.Core.Pricing
{
    public class HotelPricingId : ValueObject
    {
        public Guid Id { get; private set; }

        internal static HotelPricingId GenerateNew()
        {
            return new HotelPricingId { Id = Guid.NewGuid() };
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }
    }
}
