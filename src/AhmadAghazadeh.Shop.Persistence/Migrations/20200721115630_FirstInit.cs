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

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "Shop",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    NationalCode = table.Column<string>(type: "Char(10)", nullable: false),
                    Email = table.Column<string>(type: "NVarChar(50)", nullable: false),
                    Password = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(type: "NVarChar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "NVarChar(50)", nullable: false),
                    Score = table.Column<int>(type: "Int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.UniqueConstraint(name: "NationalCode", x => x.NationalCode);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "Shop",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    PostalCode = table.Column<string>(type: "Char(10)", nullable: true),
                    AddressLine = table.Column<string>(type: "NVarChar(250)", nullable: false),
                    CityId = table.Column<int>(type: "Int", nullable: false),
                    CustomerId = table.Column<Guid>(nullable: false),
                    Telephone = table.Column<string>(type: "Char(11)", nullable: true),
                    Coordinate = table.Column<string>(type: "NVarChar(25)", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_Address_CustomerId",
                schema: "Shop",
                table: "Address",
                column: "CustomerId");


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
                    Name = table.Column<string>(type: "Char(20)",  nullable: true),
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
                name: "Customer",
                schema: "Shop");

            migrationBuilder.DropTable(
                name: "City",
                schema: "Basic");

            migrationBuilder.DropTable(
                name: "State",
                schema: "Basic");
        }
    }
}
