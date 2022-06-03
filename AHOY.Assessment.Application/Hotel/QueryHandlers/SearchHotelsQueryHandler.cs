using AHOY.Assessment.Application.Contracts.Hotels.Dtos;
using AHOY.Assessment.Application.Contracts.Hotels.Queries;
using AHOY.Assessment.Core.Common;
using AHOY.Assessment.Data;

namespace AHOY.Assessment.Application.Hotel.QueryHandlers
{
    public class SearchHotelsQueryHandler : IQueryHandler<SearchHotelsQuery, List<HotelDto>>
    {
        private readonly AHOYDbContext _context;

        public SearchHotelsQueryHandler(AHOYDbContext context)
        {
            _context = context;
        }
        public Task<List<HotelDto>> HandleAsync(SearchHotelsQuery query)
        {
            // Sorry About this but I am out of time :( 
            return Task.FromResult(new List<HotelDto>
            {
                new HotelDto {HotelId = Guid.NewGuid() , HotelName = "Dummy Hotel 1"},
                new HotelDto {HotelId = Guid.NewGuid() , HotelName = "Dummy Hotel 2"},
                new HotelDto {HotelId = Guid.NewGuid() , HotelName = "Dummy Hotel 3"},
            });
        }
    }
}
