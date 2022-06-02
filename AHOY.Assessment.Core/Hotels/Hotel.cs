using AHOY.Assessment.Core.Countries;

namespace AHOY.Assessment.Core.Hotels
{
    public class Hotel
    {
        public HotelId Id { get; private set; }
        public HotelName Name { get; private set; }
        public Location Location { get; private set; }
        public Address Address { get; private set; }
        public CityId CityId { get; private set; }

        private List<Room> _rooms;
        public IReadOnlyList<Room> Rooms => _rooms;

        private List<Facility> _facilities;
        public IReadOnlyList<Facility> Facilities => _facilities;

        private Hotel()
        {

        }

        public static Hotel CreateNew(string name, double latitude, double longtitude, string address, CityId cityId)
        {
            return new Hotel
            {
                Id = HotelId.GenerateHotelId(),
                Name = new HotelName(name),
                Location = new Location(latitude, longtitude),
                CityId = cityId,
                Address = Address.CreateNew(address),
                _rooms = new List<Room>(),
                _facilities = new List<Facility>()
            };
        }

        public void AddRoom(int roomNumber, string name, string description, RoomType type)
        {
            if (_rooms.Any(r => r.Number.Number.Equals(roomNumber)))
            {
                throw new ArgumentException($"This facility already exisits");
            }
            _rooms.Add(Room.CreateNew(roomNumber, name, description, type));
        }

        public void AddFacility(string name)
        {
            if (_facilities.Any(f => f.Name.Name.Equals(name)))
            {
                throw new ArgumentException($"This facility already exisits");
            }

            _facilities.Add(Facility.CreateNew(name));
        }
    }
}
