using AHOY.Assessment.Core.Common;
using Ardalis.GuardClauses;

namespace AHOY.Assessment.Core.Pricing
{
    public class Price : ValueObject
    {
        public decimal Amount { get; private set; }
        public string Currency { get; private set; }

        public Price(decimal amount, string currency)
        {
            Amount = Guard.Against.NegativeOrZero(amount);
            Currency = Guard.Against.NullOrEmpty(currency);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
            yield return Currency;
        }
    }
}
