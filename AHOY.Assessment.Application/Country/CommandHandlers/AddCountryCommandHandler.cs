using AHOY.Assessment.Core.Common;
using AHOY.Assessment.Core.Countries.Commands;
using AHOY.Assessment.Data;

namespace AHOY.Assessment.Application.Country.CommandHandlers
{
    public class AddCountryCommandHandler : ICommandHandler<AddContryCommand>
    {
        private readonly AHOYDbContext _dbContext; // Should be replaced with Repository

        public AddCountryCommandHandler(AHOYDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task HandleAsync(AddContryCommand command)
        {
            var country = Core.Countries.Country.CreateNew(command.Name);
            _dbContext.Countries.Add(country); // this code should be in the infrastructure layer (Data). (Shortcut)
            await _dbContext.SaveChangesAsync();
        }
    }
}
