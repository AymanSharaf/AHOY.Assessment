namespace AHOY.Assessment.Core.Hotels
{
    public class Room
    {
        public RoomId Id { get; private set; }
        public RoomNumber Number { get; private set; }
        public RoomName Name { get; private set; }
        public RoomDescription Description { get; private set; }

        private Room()
        {

        }

        internal static Room CreateNew(int number, string name, string description)
        {
            return new Room
            {
                Id = RoomId.GenerateRoomId(),
                Number = new RoomNumber(number),
                Name = new RoomName(name),
                Description = new RoomDescription(description)
            };
        }
    }
}
