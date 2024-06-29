using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Supermarket.Infrastructure.Migrations
{
    public partial class suaimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "image",
                table: "Employees",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image",
                table: "Employees");
        }
    }
}
