using System.Data;
using AhmadAghazadeh.Framework.Persistence;
using AhmadAghazadeh.Shop.OrderContext.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AhmadAghazadeh.Shop.OrderContext.Infrastructure.Persistence.Orders.Mappings
{
    public class OrderItemMapping : EntityMappingBase<OrderItem>
    {
        public override void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            Initial(builder);


            builder.HasOne(od => od.Order)
                .WithMany(c => c.Cart);

            builder.Property(c => c.Quantity)
                .HasColumnType(SqlDbType.Int.ToString())
                .IsRequired();

            builder.Property(c => c.Price)
                .HasColumnType(SqlDbType.Float.ToString())
                .IsRequired();

            builder.Property(c => c.ProductId)
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString())
                .IsRequired();
        }
    }
}