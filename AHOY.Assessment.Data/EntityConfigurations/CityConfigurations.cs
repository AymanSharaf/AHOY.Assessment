using AHOY.Assessment.Core.Countries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AHOY.Assessment.Data.EntityConfigurations
{
    public class CityConfigurations : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("Cities");

            builder.Property(x => x.Id).HasConversion(x => x.Id, l => CityId.FromExisting(l))
                                        .HasColumnName("Id").IsRequired();

            builder.OwnsOne(c => c.Name, b => { b.Property(p => p.Value).HasMaxLength(250).HasColumnName("Name"); });

        }
    }
}
