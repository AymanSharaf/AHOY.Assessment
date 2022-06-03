using AHOY.Assessment.Application.Contracts.Hotels.Dtos;
using AHOY.Assessment.Application.Contracts.Hotels.Queries;
using AHOY.Assessment.Data;
using Microsoft.EntityFrameworkCore;

namespace AHOY.Assessment.Application.Hotel.QueryHandlers
{
    public class GetHotelQueryHandler : Core.Common.IQueryHandler<GetHotelQuery, HotelDto>
    {
        private readonly AHOYDbContext dbContext; // This db context shouldn't be used. This context is not optimized for reading
                                                  // We should have a translation layer that fill a new DB which should be read optimized 

        public GetHotelQueryHandler(AHOYDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<HotelDto> HandleAsync(GetHotelQuery query)
        {
            var hotel = await dbContext.Hotels.FirstOrDefaultAsync(h => h.Id.Equals(query.HotelId));

            if (hotel != null)
            {
                return new HotelDto
                {
                    HotelId = hotel.Id.Id,
                    HotelName = hotel.Name.Name
                };
            }

            throw new InvalidOperationException("There is no hotel with this Id"); // we should have exception handling middleware, Or Decorator on all handlers (commands,Queries) 
        }
    }
}
