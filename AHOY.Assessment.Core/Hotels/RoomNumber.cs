using AHOY.Assessment.Core.Common;
using Ardalis.GuardClauses;

namespace AHOY.Assessment.Core.Hotels
{
    public class RoomNumber : ValueObject
    {
        public int Number { get; private set; }

        public RoomNumber(int number)
        {

            Number = Guard.Against.NegativeOrZero(number);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Number;
        }
    }
}
