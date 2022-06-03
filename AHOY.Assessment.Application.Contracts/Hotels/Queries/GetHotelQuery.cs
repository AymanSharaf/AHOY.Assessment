using AHOY.Assessment.Application.Contracts.Hotels.Dtos;
using AHOY.Assessment.Core.Common;

namespace AHOY.Assessment.Application.Contracts.Hotels.Queries
{
    public class GetHotelQuery : IQuery<HotelDto>
    {
        public Guid HotelId { get; private set; }

        public GetHotelQuery(Guid hotelId)
        {
            HotelId = hotelId;
        }
    }
}
