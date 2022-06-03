using AHOY.Assessment.Core.Hotels;
using AHOY.Assessment.Core.Users;

namespace AHOY.Assessment.Core.Bookings
{
    public class Booking
    {
        public UserEmail Email { get; private set; }
        public RoomId RoomId { get; private set; }
        public HotelId HotelId { get; private set; }
        public DateTime CheckInDate { get; private set; }
        public DateTime CheckOutDate { get; private set; }
    }
}
