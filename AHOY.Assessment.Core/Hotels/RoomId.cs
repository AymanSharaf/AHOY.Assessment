using AHOY.Assessment.Core.Common;
using Ardalis.GuardClauses;

namespace AHOY.Assessment.Core.Hotels
{
    public class RoomId : ValueObject
    {
        public Guid Id { get; private set; }

        internal static RoomId GenerateRoomId()
        {
            return new RoomId { Id = Guid.NewGuid() };
        }

        public static RoomId FromExisting(Guid guid)
        {
            return new RoomId { Id = Guard.Against.Default(guid) };
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }
    }
}
