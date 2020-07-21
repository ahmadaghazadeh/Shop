using System.Data;
using AhmadAghazadeh.Framework.Persistence;
using AhmadAghazadeh.Shop.CustomerContext.Domain;
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
                .HasColumnType(SqlDbType.NVarChar+"(50)")
                .IsRequired();

            builder.Property(c => c.NationalCode)
                .HasColumnType(SqlDbType.Char+"(10)")
                .IsRequired();

            builder.Property(c => c.FirstName)
                .HasColumnType(SqlDbType.NVarChar + "(50)")
                .HasMaxLength(50)
                .IsRequired();


            builder.Property(c => c.LastName)
                .HasColumnType(SqlDbType.NVarChar + "(50)")
                .IsRequired();

            builder.Property(c => c.Score)
                .HasColumnType(SqlDbType.Int.ToString()) 
                .IsRequired();
        }
    }
}
