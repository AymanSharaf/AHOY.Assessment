using AHOY.Assessment.Core.Common;
using Ardalis.GuardClauses;

namespace AHOY.Assessment.Core.Hotels
{
    public class RoomName : ValueObject
    {
        public string Name { get; private set; }

        public RoomName(string name)
        {
            Name = Guard.Against.NullOrEmpty(name);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }
    }
}
