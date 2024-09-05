using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Supermarket.Infrastructure.Migrations
{
    public partial class movepricejoinproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "price",
                table: "StockInDetails");

            migrationBuilder.AddColumn<double>(
                name: "price",
                table: "Products",
                type: "float",
                nullable: true,
                defaultValueSql: "0.0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "price",
                table: "Products");

            migrationBuilder.AddColumn<double>(
                name: "price",
                table: "StockInDetails",
                type: "float",
                nullable: true);
        }
    }
}
