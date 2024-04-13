using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Supermarket.Infrastructure.Migrations
{
    public partial class fixNameTableVariant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VariantValuesValues",
                table: "VariantValuesValues");

            migrationBuilder.RenameTable(
                name: "VariantValuesValues",
                newName: "VariantValues");

            migrationBuilder.RenameIndex(
                name: "IX_VariantValuesValues_ProductId",
                table: "VariantValues",
                newName: "IX_VariantValues_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_VariantValuesValues_deleteBy",
                table: "VariantValues",
                newName: "IX_VariantValues_deleteBy");

            migrationBuilder.RenameIndex(
                name: "IX_VariantValuesValues_createBy",
                table: "VariantValues",
                newName: "IX_VariantValues_createBy");

            migrationBuilder.RenameIndex(
                name: "IX_VariantValuesValues_attributeId",
                table: "VariantValues",
                newName: "IX_VariantValues_attributeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VariantValues",
                table: "VariantValues",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VariantValues",
                table: "VariantValues");

            migrationBuilder.RenameTable(
                name: "VariantValues",
                newName: "VariantValuesValues");

            migrationBuilder.RenameIndex(
                name: "IX_VariantValues_ProductId",
                table: "VariantValuesValues",
                newName: "IX_VariantValuesValues_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_VariantValues_deleteBy",
                table: "VariantValuesValues",
                newName: "IX_VariantValuesValues_deleteBy");

            migrationBuilder.RenameIndex(
                name: "IX_VariantValues_createBy",
                table: "VariantValuesValues",
                newName: "IX_VariantValuesValues_createBy");

            migrationBuilder.RenameIndex(
                name: "IX_VariantValues_attributeId",
                table: "VariantValuesValues",
                newName: "IX_VariantValuesValues_attributeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VariantValuesValues",
                table: "VariantValuesValues",
                column: "id");
        }
    }
}
