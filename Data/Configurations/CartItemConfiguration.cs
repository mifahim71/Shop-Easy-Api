using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopEasyApi.Entities;

namespace ShopEasyApi.Data.Configurations
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.ToTable(nameof(CartItem));

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Quantity)
                .IsRequired();  
        }
    }
}
