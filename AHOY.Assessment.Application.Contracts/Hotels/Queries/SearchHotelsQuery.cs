using AHOY.Assessment.Application.Contracts.Hotels.Dtos;
using AHOY.Assessment.Core.Common;

namespace AHOY.Assessment.Application.Contracts.Hotels.Queries
{
    public class SearchHotelsQuery : IQuery<List<HotelDto>>
    {
        public string SearchTerm { get; private set; }

        public SearchHotelsQuery(string searchTerm)
        {
            SearchTerm = searchTerm;
        }
    }
}
