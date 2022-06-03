using AHOY.Assessment.Core.Hotels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AHOY.Assessment.Data.EntityConfigurations
{
    public class FacilityConfigurations : IEntityTypeConfiguration<Facility>
    {
        public void Configure(EntityTypeBuilder<Facility> builder)
        {
            builder.ToTable("Facilities");

            builder.Property(x => x.Id).HasConversion(x => x.Id, l => FacilityId.FromExisting(l))
                                      .HasColumnName("Id").IsRequired();

            builder.OwnsOne(c => c.Name, b => { b.Property(p => p.Name).HasMaxLength(250).HasColumnName("Name"); });

            //builder.OwnsMany(f => f.HotelIds, c =>
            //{
            //    c.WithOwner();
            //    c.ToTable("HotelFacilities");
            //});


        }
    }
}
