using System.Data;
using AhmadAghazadeh.Framework.Persistence;
using AhmadAghazadeh.Shop.CustomerContext.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AhmadAghazadeh.Shop.CustomerContext.Infrastructure.Persistence.Customers.Mappings
{
    public  class CustomerMapping:EntityMappingBase<Customer>
    { 
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            Initial(builder);
             
            builder.Property(c => c.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.NationalCode)
                .HasColumnType(SqlDbType.NChar+"(10)")
                .IsRequired();

            builder.Property(c => c.FirstName)
                .HasMaxLength(100)
                .IsRequired();


            builder.Property(c => c.LastName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Score)
                .HasColumnType(nameof(SqlDbType.Int)) 
                .IsRequired();
        }
    }
}
