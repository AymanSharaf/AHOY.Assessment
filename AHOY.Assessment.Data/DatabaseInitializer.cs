using AHOY.Assessment.Core.Common;
using Microsoft.EntityFrameworkCore;

namespace AHOY.Assessment.Data
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly AHOYDbContext _dbContext;

        public DatabaseInitializer(AHOYDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task InitializeAsync()
        {
            await _dbContext.Database.MigrateAsync();
        }
    }
}
