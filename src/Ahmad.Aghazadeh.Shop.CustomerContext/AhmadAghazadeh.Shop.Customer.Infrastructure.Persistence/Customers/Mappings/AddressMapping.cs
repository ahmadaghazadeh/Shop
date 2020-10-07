using System.Data;
using AhmadAghazadeh.Framework.Persistence;
using AhmadAghazadeh.Shop.CustomerContext.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AhmadAghazadeh.Shop.CustomerContext.Infrastructure.Persistence.Customers.Mappings
{
    public class AddressMapping : EntityMappingBase<Address>
    {
        public override void Configure(EntityTypeBuilder<Address> builder)
        {
            Initial(builder);

            builder.HasOne(a=>a.Customer)
                .WithMany(c=>c.Addresses);
        

            builder.Property(a => a.AddressLine)
                .HasMaxLength(250)
                 
                .IsRequired();

            builder.Property(a => a.CityId)
                .HasColumnType(nameof(SqlDbType.Int))
                .IsRequired();


            builder.Property(a => a.PostalCode)
                .HasColumnType(nameof(SqlDbType.NChar) + "(10)") ;

            builder.Property(a => a.Telephone)
                .HasColumnType(nameof(SqlDbType.NChar) + "(11)") ;


        }
    }
}