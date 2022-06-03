using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AHOY.Assessment.Data
{
    public class AHOYDbContextFactory : IDesignTimeDbContextFactory<AHOYDbContext>
    {
        private readonly IConfiguration configuration;

        public AHOYDbContextFactory()
        {
        }
        public AHOYDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AHOYDbContext>();

            optionsBuilder.UseSqlServer("Server=tcp:localhost,1433;Initial Catalog=AHOYDB;User Id=sa;Password=P@ssword; "); // Could be read from environment variable 

            return new AHOYDbContext(optionsBuilder.Options); // That's ok here because AHOYDbContext is considered a "Local Default"
        }
    }
}
