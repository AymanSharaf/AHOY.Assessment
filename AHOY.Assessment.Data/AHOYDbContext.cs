using AHOY.Assessment.Core.Countries;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AHOY.Assessment.Data
{
    public class AHOYDbContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        //public DbSet<Hotel> Hotels { get; set; }
        //public DbSet<Room> Rooms { get; set; }
        //public DbSet<Facility> Facilities { get; set; }
        //public DbSet<HotelReview> HotelReviews { get; set; }
        //public DbSet<Review> Reviews { get; set; }
        //public DbSet<StarRating> StarRatings { get; set; }
        //public DbSet<HotelPricing> HotelPricings { get; set; }
        //public DbSet<RoomTypePricing> RoomTypePricings { get; set; }
        //public DbSet<UserEmail> Users { get; set; }

        public AHOYDbContext(DbContextOptions options) : base(options)
        {
            //Database.EnsureCreated();
            //Database.Migrate(); // This is only a shortcut because SQL Client is not loaded correctly 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Assembly assemblyWithConfigurations = GetType().Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assemblyWithConfigurations);
        }
    }
}
