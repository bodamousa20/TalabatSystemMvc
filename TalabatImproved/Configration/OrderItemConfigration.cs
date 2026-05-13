using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TalabatSmartVillage.Models;

namespace TalabatSmartVillage.Configration
{
    public class OrderItemConfigration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(p => p.OrderId)
                    .OnDelete(DeleteBehavior.NoAction);

          

        }
    }

}
