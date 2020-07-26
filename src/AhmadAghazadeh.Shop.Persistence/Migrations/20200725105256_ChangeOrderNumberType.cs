using Microsoft.EntityFrameworkCore.Migrations;

namespace AhmadAghazadeh.Shop.Persistence.Migrations
{
    public partial class ChangeOrderNumberType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "Order",
                schema: "Shared");

            migrationBuilder.AlterColumn<long>(
                name: "Number",
                schema: "Shop",
                table: "Order",
                type: "BigInt",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "Int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Shared");

            migrationBuilder.CreateSequence(
                name: "Order",
                schema: "Shared");

            migrationBuilder.AlterColumn<int>(
                name: "Number",
                schema: "Shop",
                table: "Order",
                type: "Int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "BigInt");
        }
    }
}
