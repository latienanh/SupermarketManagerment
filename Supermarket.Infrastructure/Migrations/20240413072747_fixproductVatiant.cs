using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Supermarket.Infrastructure.Migrations
{
    public partial class fixproductVatiant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttributeValues_AppUsers_Create",
                table: "AttributeValues");

            migrationBuilder.DropForeignKey(
                name: "FK_AttributeValues_Attributes2",
                table: "AttributeValues");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetails_Variants",
                table: "InvoiceDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_StockInDetails_Variants",
                table: "StockInDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_UnitConversions_Variants",
                table: "UnitConversions");

            migrationBuilder.DropTable(
                name: "VariantBatches");

            migrationBuilder.DropTable(
                name: "Variants");

            migrationBuilder.DropIndex(
                name: "IX_UnitConversions_variantId",
                table: "UnitConversions");

            migrationBuilder.DropIndex(
                name: "IX_StockInDetails_variantId",
                table: "StockInDetails");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceDetails_variantId",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "variantId",
                table: "UnitConversions");

            migrationBuilder.DropColumn(
                name: "createBy",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "createTime",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "deleteBy",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "isDelete",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "attributeValue",
                table: "AttributeValues");

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AttributeValueName",
                table: "AttributeValues",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "AttributeValues",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UnitConversions_deleteBy",
                table: "UnitConversions",
                column: "deleteBy");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_deleteBy",
                table: "Suppliers",
                column: "deleteBy");

            migrationBuilder.CreateIndex(
                name: "IX_StockIns_deleteBy",
                table: "StockIns",
                column: "deleteBy");

            migrationBuilder.CreateIndex(
                name: "IX_StockInDetails_DeleteBy",
                table: "StockInDetails",
                column: "DeleteBy");

            migrationBuilder.CreateIndex(
                name: "IX_Products_deleteBy",
                table: "Products",
                column: "deleteBy");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ParentId",
                table: "Products",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberShipTypes_DeleteBy",
                table: "MemberShipTypes",
                column: "DeleteBy");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_deleteBy",
                table: "Invoices",
                column: "deleteBy");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_DeleteBy",
                table: "InvoiceDetails",
                column: "DeleteBy");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_deleteBy",
                table: "Customers",
                column: "deleteBy");

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_deleteBy",
                table: "Coupons",
                column: "deleteBy");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_deleteBy",
                table: "Categories",
                column: "deleteBy");

            migrationBuilder.CreateIndex(
                name: "IX_Batches_deleteBy",
                table: "Batches",
                column: "deleteBy");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValues_deleteBy",
                table: "AttributeValues",
                column: "deleteBy");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValues_ProductId",
                table: "AttributeValues",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_deleteBy",
                table: "Attributes",
                column: "deleteBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Attributes_AppUsers_Delete",
                table: "Attributes",
                column: "deleteBy",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VariantValue_Attributes",
                table: "AttributeValues",
                column: "attributeId",
                principalTable: "Attributes",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_VariantValue_Product",
                table: "AttributeValues",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_VariantValues_AppUsers_Create",
                table: "AttributeValues",
                column: "createBy",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VariantValues_AppUsers_Delete",
                table: "AttributeValues",
                column: "deleteBy",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Batches_AppUsers_Delete",
                table: "Batches",
                column: "deleteBy",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_AppUsers_Delete",
                table: "Categories",
                column: "deleteBy",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Coupons_AppUsers_Delete",
                table: "Coupons",
                column: "deleteBy",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AppUsers_Delete",
                table: "Customers",
                column: "deleteBy",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoicesDetails_AppUsers_Delete",
                table: "InvoiceDetails",
                column: "DeleteBy",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_AppUsers_Delete",
                table: "Invoices",
                column: "deleteBy",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MemberShipTypes_AppUsers_Delete",
                table: "MemberShipTypes",
                column: "DeleteBy",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Product",
                table: "Products",
                column: "ParentId",
                principalTable: "Products",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AppUsers_Delete",
                table: "Products",
                column: "deleteBy",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StockInsDetails_AppUsers_Delete",
                table: "StockInDetails",
                column: "DeleteBy",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StockIns_AppUsers_Delete",
                table: "StockIns",
                column: "deleteBy",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_AppUsers_Delete",
                table: "Suppliers",
                column: "deleteBy",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UnitConversions_AppUsers_Delete",
                table: "UnitConversions",
                column: "deleteBy",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attributes_AppUsers_Delete",
                table: "Attributes");

            migrationBuilder.DropForeignKey(
                name: "FK_VariantValue_Attributes",
                table: "AttributeValues");

            migrationBuilder.DropForeignKey(
                name: "FK_VariantValue_Product",
                table: "AttributeValues");

            migrationBuilder.DropForeignKey(
                name: "FK_VariantValues_AppUsers_Create",
                table: "AttributeValues");

            migrationBuilder.DropForeignKey(
                name: "FK_VariantValues_AppUsers_Delete",
                table: "AttributeValues");

            migrationBuilder.DropForeignKey(
                name: "FK_Batches_AppUsers_Delete",
                table: "Batches");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_AppUsers_Delete",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Coupons_AppUsers_Delete",
                table: "Coupons");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AppUsers_Delete",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoicesDetails_AppUsers_Delete",
                table: "InvoiceDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_AppUsers_Delete",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_MemberShipTypes_AppUsers_Delete",
                table: "MemberShipTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Product",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_AppUsers_Delete",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_StockInsDetails_AppUsers_Delete",
                table: "StockInDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_StockIns_AppUsers_Delete",
                table: "StockIns");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_AppUsers_Delete",
                table: "Suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_UnitConversions_AppUsers_Delete",
                table: "UnitConversions");

            migrationBuilder.DropIndex(
                name: "IX_UnitConversions_deleteBy",
                table: "UnitConversions");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_deleteBy",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_StockIns_deleteBy",
                table: "StockIns");

            migrationBuilder.DropIndex(
                name: "IX_StockInDetails_DeleteBy",
                table: "StockInDetails");

            migrationBuilder.DropIndex(
                name: "IX_Products_deleteBy",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ParentId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_MemberShipTypes_DeleteBy",
                table: "MemberShipTypes");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_deleteBy",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceDetails_DeleteBy",
                table: "InvoiceDetails");

            migrationBuilder.DropIndex(
                name: "IX_Customers_deleteBy",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Coupons_deleteBy",
                table: "Coupons");

            migrationBuilder.DropIndex(
                name: "IX_Categories_deleteBy",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Batches_deleteBy",
                table: "Batches");

            migrationBuilder.DropIndex(
                name: "IX_AttributeValues_deleteBy",
                table: "AttributeValues");

            migrationBuilder.DropIndex(
                name: "IX_AttributeValues_ProductId",
                table: "AttributeValues");

            migrationBuilder.DropIndex(
                name: "IX_Attributes_deleteBy",
                table: "Attributes");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AttributeValueName",
                table: "AttributeValues");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "AttributeValues");

            migrationBuilder.AddColumn<int>(
                name: "variantId",
                table: "UnitConversions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "createBy",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "createTime",
                table: "Employees",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "deleteBy",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDelete",
                table: "Employees",
                type: "bit",
                nullable: true,
                defaultValueSql: "((0))");

            migrationBuilder.AddColumn<string>(
                name: "attributeValue",
                table: "AttributeValues",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Variants",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    attributeValueId = table.Column<int>(type: "int", nullable: true),
                    createBy = table.Column<int>(type: "int", nullable: true),
                    productId = table.Column<int>(type: "int", nullable: true),
                    buyingPrice = table.Column<double>(type: "float", nullable: true),
                    createTime = table.Column<DateTime>(type: "date", nullable: false),
                    deleteBy = table.Column<int>(type: "int", nullable: true),
                    imageProductVariant = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    isDelete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    quantity = table.Column<int>(type: "int", nullable: true),
                    salePrice = table.Column<double>(type: "float", nullable: true),
                    sku = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variants", x => x.id);
                    table.ForeignKey(
                        name: "FK_Variants_AppUsers_Create",
                        column: x => x.createBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Variants_AttributeValues",
                        column: x => x.attributeValueId,
                        principalTable: "AttributeValues",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_VaritionOptions_Products",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "VariantBatches",
                columns: table => new
                {
                    variantId = table.Column<int>(type: "int", nullable: false),
                    batchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaritionBatches", x => new { x.variantId, x.batchId });
                    table.ForeignKey(
                        name: "FK_VariantBatches_Variants",
                        column: x => x.variantId,
                        principalTable: "Variants",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_VaritionBatches_Batches",
                        column: x => x.batchId,
                        principalTable: "Batches",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UnitConversions_variantId",
                table: "UnitConversions",
                column: "variantId");

            migrationBuilder.CreateIndex(
                name: "IX_StockInDetails_variantId",
                table: "StockInDetails",
                column: "variantId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_variantId",
                table: "InvoiceDetails",
                column: "variantId");

            migrationBuilder.CreateIndex(
                name: "IX_VariantBatches_batchId",
                table: "VariantBatches",
                column: "batchId");

            migrationBuilder.CreateIndex(
                name: "IX_Variants_attributeValueId",
                table: "Variants",
                column: "attributeValueId");

            migrationBuilder.CreateIndex(
                name: "IX_Variants_createBy",
                table: "Variants",
                column: "createBy");

            migrationBuilder.CreateIndex(
                name: "IX_Variants_productId",
                table: "Variants",
                column: "productId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttributeValues_AppUsers_Create",
                table: "AttributeValues",
                column: "createBy",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AttributeValues_Attributes2",
                table: "AttributeValues",
                column: "attributeId",
                principalTable: "Attributes",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetails_Variants",
                table: "InvoiceDetails",
                column: "variantId",
                principalTable: "Variants",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_StockInDetails_Variants",
                table: "StockInDetails",
                column: "variantId",
                principalTable: "Variants",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_UnitConversions_Variants",
                table: "UnitConversions",
                column: "variantId",
                principalTable: "Variants",
                principalColumn: "id");
        }
    }
}
