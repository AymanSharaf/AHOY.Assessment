using AHOY.Assessment.Core.Common;

namespace AHOY.Assessment.Core.Hotels
{
    public class RoomId : ValueObject
    {
        public Guid Id { get; private set; }

        internal static RoomId GenerateRoomId()
        {
            return new RoomId { Id = Guid.NewGuid() };
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }
    }
}
