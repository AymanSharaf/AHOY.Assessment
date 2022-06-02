using AHOY.Assessment.Core.Common;
using Ardalis.GuardClauses;

namespace AHOY.Assessment.Core.Hotels
{
    public class HotelMapUrl : ValueObject
    {
        public string Url { get; private set; }

        public HotelMapUrl(string url)
        {
            Url = Guard.Against.NullOrEmpty(url);
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Url;
        }
    }
}
