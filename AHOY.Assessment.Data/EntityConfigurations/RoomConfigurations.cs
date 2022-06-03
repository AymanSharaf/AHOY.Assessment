using AHOY.Assessment.Core.Hotels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AHOY.Assessment.Data.EntityConfigurations
{
    public class RoomConfigurations : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("Rooms");


            builder.Property(x => x.Id).HasConversion(x => x.Id, l => RoomId.FromExisting(l))
                                      .HasColumnName("Id").IsRequired();

            builder.OwnsOne(c => c.Name, b => { b.Property(p => p.Name).HasMaxLength(250).HasColumnName("Name"); });

            builder.OwnsOne(c => c.Description, b =>
            {
                b.Property(p => p.Description)
                      .HasMaxLength(500).HasColumnName("Description");
            });

            builder.OwnsOne(c => c.Number, b => { b.Property(p => p.Number).HasColumnName("RoomName"); });


        }
    }
}
