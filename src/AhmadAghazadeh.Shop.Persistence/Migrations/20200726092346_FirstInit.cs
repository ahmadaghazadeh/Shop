using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AhmadAghazadeh.Shop.Persistence.Migrations
{
    public partial class FirstInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Basic");

            migrationBuilder.EnsureSchema(
                name: "Shop");

            migrationBuilder.EnsureSchema(
                name: "Shared");

            migrationBuilder.CreateSequence(
                name: "Order",
                schema: "Shared");

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "Shop",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    NationalCode = table.Column<string>(type: "NChar(10)", nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Password = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    Score = table.Column<int>(type: "Int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "Shop",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    Number = table.Column<long>(type: "BigInt", nullable: false),
                    Tax = table.Column<double>(type: "Float", nullable: false),
                    ShippingCost = table.Column<double>(type: "Float", nullable: false),
                    TotalAmount = table.Column<double>(type: "Float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "Shop",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    PostalCode = table.Column<string>(type: "NChar(10)", nullable: true),
                    AddressLine = table.Column<string>(maxLength: 250, nullable: false),
                    CityId = table.Column<int>(type: "Int", nullable: false),
                    CustomerId = table.Column<Guid>(nullable: false),
                    Telephone = table.Column<string>(type: "NChar(11)", nullable: true),
                    Coordinate = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Shop",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                schema: "Shop",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    OrderId = table.Column<Guid>(nullable: true),
                    ProductId = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    Quantity = table.Column<int>(type: "Int", nullable: false),
                    Price = table.Column<double>(type: "Float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "Shop",
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CustomerId",
                schema: "Shop",
                table: "Address",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                schema: "Shop",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateTable(
                name: "State",
                schema: "Basic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "Int", nullable: false),
                    Name = table.Column<string>(type: "Char(20)", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                });


            migrationBuilder.CreateTable(
                name: "City",
                schema: "Basic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "Int", nullable: false),
                    Name = table.Column<string>(type: "Char(20)", nullable: true),
                    StateId = table.Column<int>(type: "Int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_State_CityId",
                        column: x => x.StateId,
                        principalSchema: "Basic",
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_StateId",
                schema: "Basic",
                table: "City",
                column: "StateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address",
                schema: "Shop");

            migrationBuilder.DropTable(
                name: "OrderItem",
                schema: "Shop");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "Shop");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "Shop");

            migrationBuilder.DropTable(
                name: "City",
                schema: "Basic");

            migrationBuilder.DropTable(
                name: "State",
                schema: "Basic");


            migrationBuilder.DropSequence(
                name: "Order",
                schema: "Shared");
        }
    }
}
