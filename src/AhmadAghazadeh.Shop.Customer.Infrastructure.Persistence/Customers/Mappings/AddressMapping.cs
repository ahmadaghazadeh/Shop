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
                .HasColumnType(SqlDbType.NVarChar +"250")
                 
                .IsRequired();

            builder.Property(a => a.CityId)
                .HasColumnType(SqlDbType.Int.ToString())
                .IsRequired();


            builder.Property(a => a.Coordinate)
                .HasColumnType(SqlDbType.NVarChar.ToString() + "25") ;

            builder.Property(a => a.PostalCode)
                .HasColumnType(SqlDbType.Char.ToString() + "10") ;

            builder.Property(a => a.Telephone)
                .HasColumnType(SqlDbType.Char.ToString() + "11") ;


        }
    }
}