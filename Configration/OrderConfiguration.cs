using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TalabatSmartVillage.Models;

namespace TalabatSmartVillage.Configration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(p => p.UserId);

            builder.HasOne(p => p.Restaurant)
               .WithMany(p => p.Orders)
               .HasForeignKey(p => p.RestaurantId);

            builder.HasMany(o=>o.OrderItems)
                .WithOne(o=>o.order)
                .HasForeignKey(p => p.OrderId);
            


        }
    }

}
