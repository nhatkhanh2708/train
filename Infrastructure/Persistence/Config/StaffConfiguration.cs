using Domain.Entities.StaffAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Config
{
    public class StaffConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.OwnsOne(s => s.Address);
            builder.Property(s => s.Phone)
                .HasMaxLength(10)
                .IsRequired();
            builder.Property(s => s.Img).HasColumnType("image");
        }
    }
}
