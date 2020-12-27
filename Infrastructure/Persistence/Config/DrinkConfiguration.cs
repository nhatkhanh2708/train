using Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Config
{
    public class DrinkConfiguration : IEntityTypeConfiguration<Drink>
    {
        public void Configure(EntityTypeBuilder<Drink> builder)
        {
            builder.Property(m => m.Name)
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(m => m.Price)
                .HasMaxLength(10)
                .IsRequired();
            builder.Property(m => m.Img).HasColumnType("image");
        }
    }
}
