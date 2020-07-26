﻿// <auto-generated />
using System;
using AhmadAghazadeh.Shop.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AhmadAghazadeh.Shop.Persistence.Migrations
{
    [DbContext(typeof(ShopDbContext))]
    partial class ShopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AhmadAghazadeh.Shop.CustomerContext.Domain.Customers.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("UniqueIdentifier");

                    b.Property<string>("AddressLine")
                        .IsRequired()
                        .HasColumnType("NVarChar(250)");

                    b.Property<int>("CityId")
                        .HasColumnType("Int");

                    b.Property<string>("Coordinate")
                        .HasColumnType("NVarChar(25)");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("UniqueIdentifier");

                    b.Property<string>("PostalCode")
                        .HasColumnType("Char(10)");

                    b.Property<string>("Telephone")
                        .HasColumnType("Char(11)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Address","Shop");
                });

            modelBuilder.Entity("AhmadAghazadeh.Shop.CustomerContext.Domain.Customers.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("UniqueIdentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVarChar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("NVarChar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("NVarChar(50)");

                    b.Property<string>("NationalCode")
                        .IsRequired()
                        .HasColumnType("Char(10)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Score")
                        .HasColumnType("Int");

                    b.HasKey("Id");

                    b.ToTable("Customer","Shop");
                });

            modelBuilder.Entity("AhmadAghazadeh.Shop.OrderContext.Domain.Orders.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("UniqueIdentifier");

                    b.Property<long>("Number")
                        .HasColumnType("BigInt");

                    b.Property<double>("ShippingCost")
                        .HasColumnType("Float");

                    b.Property<double>("Tax")
                        .HasColumnType("Float");

                    b.Property<double>("TotalAmount")
                        .HasColumnType("Float");

                    b.HasKey("Id");

                    b.ToTable("Order","Shop");
                });

            modelBuilder.Entity("AhmadAghazadeh.Shop.OrderContext.Domain.Orders.OrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("UniqueIdentifier");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("UniqueIdentifier");

                    b.Property<double>("Price")
                        .HasColumnType("Float");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("UniqueIdentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("Int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItem","Shop");
                });

            modelBuilder.Entity("AhmadAghazadeh.Shop.CustomerContext.Domain.Customers.Address", b =>
                {
                    b.HasOne("AhmadAghazadeh.Shop.CustomerContext.Domain.Customers.Customer", "Customer")
                        .WithMany("Addresses")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AhmadAghazadeh.Shop.OrderContext.Domain.Orders.OrderItem", b =>
                {
                    b.HasOne("AhmadAghazadeh.Shop.OrderContext.Domain.Orders.Order", "Order")
                        .WithMany("Cart")
                        .HasForeignKey("OrderId");
                });
#pragma warning restore 612, 618
        }
    }
}
