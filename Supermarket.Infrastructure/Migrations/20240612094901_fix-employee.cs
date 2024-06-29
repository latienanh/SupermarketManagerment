using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Supermarket.Infrastructure.Migrations
{
    public partial class fixemployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AppUsers",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_UserId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "productSlug",
                table: "Products",
                newName: "slug");

            migrationBuilder.RenameColumn(
                name: "productName",
                table: "Products",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "productImage",
                table: "Products",
                newName: "image");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Employees",
                newName: "deleteBy");

            migrationBuilder.RenameColumn(
                name: "categoryName",
                table: "Categories",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "attributeName",
                table: "Attributes",
                newName: "name");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "firstName",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "lastName",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                table: "StockIns",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                table: "Invoices",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "createBy",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "createTime",
                table: "Employees",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "isDelete",
                table: "Employees",
                type: "bit",
                nullable: true,
                defaultValueSql: "((0))");

            migrationBuilder.AddColumn<string>(
                name: "Describe",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "fullName",
                table: "Users",
                type: "nvarchar(101)",
                maxLength: 101,
                nullable: true,
                computedColumnSql: "(([firstName]+' ')+[lastName])",
                stored: false);

            migrationBuilder.CreateIndex(
                name: "IX_StockIns_EmployeeId",
                table: "StockIns",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_EmployeeId",
                table: "Invoices",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_createBy",
                table: "Employees",
                column: "createBy");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_deleteBy",
                table: "Employees",
                column: "deleteBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_AppUsers_Create",
                table: "Employees",
                column: "createBy",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_AppUsers_Delete",
                table: "Employees",
                column: "deleteBy",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Employees",
                table: "Invoices",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockIns_Employees",
                table: "StockIns",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_AppUsers_Create",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_AppUsers_Delete",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Employees",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_StockIns_Employees",
                table: "StockIns");

            migrationBuilder.DropIndex(
                name: "IX_StockIns_EmployeeId",
                table: "StockIns");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_EmployeeId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Employees_createBy",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_deleteBy",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "fullName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "firstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "lastName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "StockIns");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "createBy",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "createTime",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "isDelete",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Describe",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "slug",
                table: "Products",
                newName: "productSlug");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Products",
                newName: "productName");

            migrationBuilder.RenameColumn(
                name: "image",
                table: "Products",
                newName: "productImage");

            migrationBuilder.RenameColumn(
                name: "deleteBy",
                table: "Employees",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Categories",
                newName: "categoryName");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Attributes",
                newName: "attributeName");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_AppUsers",
                table: "Employees",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
