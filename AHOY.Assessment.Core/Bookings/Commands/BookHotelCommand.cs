using AHOY.Assessment.Core.Common;

namespace AHOY.Assessment.Core.Bookings.Commands
{
    public class BookHotelCommand : ICommand
    {
        public Guid HotelId { get; private set; }
        public Guid RoomId { get; private set; }
        public string UserEmail { get; private set; }

        public BookHotelCommand(Guid hotelId, Guid roomId, string userEmail)
        {
            HotelId = hotelId;
            RoomId = roomId;
            UserEmail = userEmail;
        }
    }
}
