namespace AHOY.Assessment.Application.Contracts.Bookings.Dtos
{
    public class BookingDto
    {
        public Guid HotelId { get; set; }
        public Guid RoomId { get; set; }
        public string UserEmail { get; set; }
    }
}
