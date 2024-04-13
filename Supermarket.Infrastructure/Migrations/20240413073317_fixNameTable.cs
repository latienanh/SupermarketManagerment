using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Supermarket.Infrastructure.Migrations
{
    public partial class fixNameTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AttributeValues",
                table: "AttributeValues");

            migrationBuilder.RenameTable(
                name: "AttributeValues",
                newName: "VariantValuesValues");

            migrationBuilder.RenameIndex(
                name: "IX_AttributeValues_ProductId",
                table: "VariantValuesValues",
                newName: "IX_VariantValuesValues_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_AttributeValues_deleteBy",
                table: "VariantValuesValues",
                newName: "IX_VariantValuesValues_deleteBy");

            migrationBuilder.RenameIndex(
                name: "IX_AttributeValues_createBy",
                table: "VariantValuesValues",
                newName: "IX_VariantValuesValues_createBy");

            migrationBuilder.RenameIndex(
                name: "IX_AttributeValues_attributeId",
                table: "VariantValuesValues",
                newName: "IX_VariantValuesValues_attributeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VariantValuesValues",
                table: "VariantValuesValues",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VariantValuesValues",
                table: "VariantValuesValues");

            migrationBuilder.RenameTable(
                name: "VariantValuesValues",
                newName: "AttributeValues");

            migrationBuilder.RenameIndex(
                name: "IX_VariantValuesValues_ProductId",
                table: "AttributeValues",
                newName: "IX_AttributeValues_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_VariantValuesValues_deleteBy",
                table: "AttributeValues",
                newName: "IX_AttributeValues_deleteBy");

            migrationBuilder.RenameIndex(
                name: "IX_VariantValuesValues_createBy",
                table: "AttributeValues",
                newName: "IX_AttributeValues_createBy");

            migrationBuilder.RenameIndex(
                name: "IX_VariantValuesValues_attributeId",
                table: "AttributeValues",
                newName: "IX_AttributeValues_attributeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AttributeValues",
                table: "AttributeValues",
                column: "id");
        }
    }
}
