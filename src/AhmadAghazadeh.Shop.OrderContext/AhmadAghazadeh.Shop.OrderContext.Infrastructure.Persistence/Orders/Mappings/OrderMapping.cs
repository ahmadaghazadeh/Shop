using System.Data;
using AhmadAghazadeh.Framework.Persistence;
using AhmadAghazadeh.Shop.OrderContext.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AhmadAghazadeh.Shop.OrderContext.Infrastructure.Persistence.Orders.Mappings
{
    public class OrderMapping : EntityMappingBase<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            Initial(builder);

            
            builder.Property(c => c.Number)
                .HasColumnType(nameof(SqlDbType.BigInt))
                .IsRequired();

            builder.Property(c => c.ShippingCost)
                .HasColumnType(nameof(SqlDbType.Float))
                .IsRequired();

            builder.Property(c => c.TotalAmount)
                .HasColumnType(nameof(SqlDbType.Float))
                .IsRequired();


            builder.Property(c => c.Tax)
                .HasColumnType(nameof(SqlDbType.Float))
                .IsRequired();

             
        }
    }
}
