using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Supermarket.Infrastructure.Migrations
{
    public partial class addStock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreateBy",
                table: "StockInDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "StockInDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeleteBy",
                table: "StockInDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "StockInDetails",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreateBy",
                table: "MemberShipTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "MemberShipTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeleteBy",
                table: "MemberShipTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "MemberShipTypes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreateBy",
                table: "InvoiceDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "InvoiceDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeleteBy",
                table: "InvoiceDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "InvoiceDetails",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockInDetails_CreateBy",
                table: "StockInDetails",
                column: "CreateBy");

            migrationBuilder.CreateIndex(
                name: "IX_MemberShipTypes_CreateBy",
                table: "MemberShipTypes",
                column: "CreateBy");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_CreateBy",
                table: "InvoiceDetails",
                column: "CreateBy");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoicesDetails_AppUsers_Create",
                table: "InvoiceDetails",
                column: "CreateBy",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MemberShipTypes_AppUsers_Create",
                table: "MemberShipTypes",
                column: "CreateBy",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StockInsDetails_AppUsers_Create",
                table: "StockInDetails",
                column: "CreateBy",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoicesDetails_AppUsers_Create",
                table: "InvoiceDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_MemberShipTypes_AppUsers_Create",
                table: "MemberShipTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_StockInsDetails_AppUsers_Create",
                table: "StockInDetails");

            migrationBuilder.DropIndex(
                name: "IX_StockInDetails_CreateBy",
                table: "StockInDetails");

            migrationBuilder.DropIndex(
                name: "IX_MemberShipTypes_CreateBy",
                table: "MemberShipTypes");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceDetails_CreateBy",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "StockInDetails");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "StockInDetails");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "StockInDetails");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "StockInDetails");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "MemberShipTypes");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "MemberShipTypes");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "MemberShipTypes");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "MemberShipTypes");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "InvoiceDetails");
        }
    }
}
