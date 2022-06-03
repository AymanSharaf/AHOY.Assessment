using AHOY.Assessment.Core.Countries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AHOY.Assessment.Data.EntityConfigurations
{
    public class CountryConfigurations : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            //builder.OwnsOne(c => c.Id, b =>
            //{
            //    b.WithOwner();
            //    b.Property(p => p.Id).HasColumnName("Id");

            //});
            builder.ToTable("Countries");
            //builder.HasKey(p => p.Id);
            builder.Property(x => x.Id).HasConversion(x => x.Id, l => CountryId.FromExisting(l)).HasColumnName("Id").IsRequired();
            builder.OwnsOne(c => c.Name, b => { b.Property(p => p.Value).HasMaxLength(250).HasColumnName("Name"); });
            builder.Ignore(p => p.Cities);
        }
    }
}
