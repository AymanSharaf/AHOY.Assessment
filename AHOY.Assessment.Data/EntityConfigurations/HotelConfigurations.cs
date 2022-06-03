using AHOY.Assessment.Core.Countries;
using AHOY.Assessment.Core.Hotels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AHOY.Assessment.Data.EntityConfigurations
{
    public class HotelConfigurations : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.ToTable("Hotels");

            builder.Property(x => x.Id).HasConversion(x => x.Id, l => HotelId.FromExisting(l))
                                      .HasColumnName("Id").IsRequired();

            builder.OwnsOne(c => c.Name, b => { b.Property(p => p.Name).HasMaxLength(250).HasColumnName("Name"); });

            builder.OwnsOne(c => c.Address, b => { b.Property(p => p.Value).HasMaxLength(250).HasColumnName("Address"); });

            builder.OwnsOne(c => c.Location, b =>
            {
                b.Property(p => p.Latitude).HasColumnName("Latitude");
                b.Property(p => p.Longitude).HasColumnName("Longitude");
            });

            builder.HasOne<City>().WithMany().HasForeignKey("CityId").IsRequired();

            builder.Property(x => x.CityId).HasConversion(x => x.Id, l => CityId.FromExisting(l))
                        .HasColumnName("CityId");

            builder.HasMany(h => h.Rooms).WithOne().IsRequired().HasForeignKey("HotelId");

            builder.HasMany(h => h.Facilities).WithMany("_hotels").UsingEntity<Dictionary<string, object>>(
        "HotelFacilities",
        j => j
            .HasOne<Facility>()
            .WithMany()
            .HasForeignKey("FacilityId")
            .HasConstraintName("FK_HotelFacilities_Facility_FacilityId")
            .OnDelete(DeleteBehavior.Cascade),
        j => j
            .HasOne<Hotel>()
            .WithMany()
            .HasForeignKey("HotelId")
            .HasConstraintName("FK_HotelFacilities_Hotels_HotelId")
            .OnDelete(DeleteBehavior.ClientCascade)); ;
        }
    }
}
