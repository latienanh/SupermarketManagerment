using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Supermarket.Infrastructure.Migrations
{
    public partial class FirstDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MemberShipTypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberShipTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attributes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    attributeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    isDelete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    createBy = table.Column<int>(type: "int", nullable: true),
                    createTime = table.Column<DateTime>(type: "date", nullable: false),
                    modifiedBy = table.Column<int>(type: "int", nullable: true),
                    modifiedTime = table.Column<DateTime>(type: "date", nullable: false),
                    deleteBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Attributes_AppUsers_Create",
                        column: x => x.createBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Batches",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    batchNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    manufacturingDate = table.Column<DateTime>(type: "date", nullable: true),
                    expiryDate = table.Column<DateTime>(type: "date", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: true),
                    isDelete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    createBy = table.Column<int>(type: "int", nullable: true),
                    createTime = table.Column<DateTime>(type: "date", nullable: false),
                    modifiedBy = table.Column<int>(type: "int", nullable: true),
                    modifiedTime = table.Column<DateTime>(type: "date", nullable: false),
                    deleteBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batches", x => x.id);
                    table.ForeignKey(
                        name: "FK_Batches_AppUsers_Create",
                        column: x => x.createBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    parentId = table.Column<int>(type: "int", nullable: true),
                    categoryName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    isDelete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    createBy = table.Column<int>(type: "int", nullable: true),
                    createTime = table.Column<DateTime>(type: "date", nullable: false),
                    modifiedBy = table.Column<int>(type: "int", nullable: true),
                    modifiedTime = table.Column<DateTime>(type: "date", nullable: false),
                    deleteBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.id);
                    table.ForeignKey(
                        name: "FK_Categories_AppUsers_Create",
                        column: x => x.createBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Categories_Categories",
                        column: x => x.parentId,
                        principalTable: "Categories",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    couponDescripiton = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    discountValue = table.Column<double>(type: "float", nullable: true),
                    discountType = table.Column<int>(type: "int", nullable: true),
                    couponStartDate = table.Column<DateTime>(type: "date", nullable: true),
                    couponEndDate = table.Column<DateTime>(type: "date", nullable: true),
                    isDelete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    createBy = table.Column<int>(type: "int", nullable: true),
                    createTime = table.Column<DateTime>(type: "date", nullable: false),
                    modifiedBy = table.Column<int>(type: "int", nullable: true),
                    modifiedTime = table.Column<DateTime>(type: "date", nullable: false),
                    deleteBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.id);
                    table.ForeignKey(
                        name: "FK_Coupons_AppUsers_Create",
                        column: x => x.createBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    fullName = table.Column<string>(type: "nvarchar(101)", maxLength: 101, nullable: true, computedColumnSql: "(([firstName]+' ')+[lastName])", stored: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phoneNumber = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    membershipTypeId = table.Column<int>(type: "int", nullable: true),
                    isDelete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    createBy = table.Column<int>(type: "int", nullable: true),
                    createTime = table.Column<DateTime>(type: "date", nullable: false),
                    modifiedBy = table.Column<int>(type: "int", nullable: true),
                    modifiedTime = table.Column<DateTime>(type: "date", nullable: false),
                    deleteBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.id);
                    table.ForeignKey(
                        name: "FK_Customers_AppUsers_Create",
                        column: x => x.createBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Customers_membershipType",
                        column: x => x.membershipTypeId,
                        principalTable: "MemberShipTypes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    fullName = table.Column<string>(type: "nvarchar(101)", maxLength: 101, nullable: true, computedColumnSql: "(([firstName]+' ')+[lastName])", stored: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    isDelete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    createBy = table.Column<int>(type: "int", nullable: true),
                    createTime = table.Column<DateTime>(type: "date", nullable: false),
                    modifiedBy = table.Column<int>(type: "int", nullable: true),
                    modifiedTime = table.Column<DateTime>(type: "date", nullable: false),
                    deleteBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.id);
                    table.ForeignKey(
                        name: "FK_Employees_AppUsers",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    barCode = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    productName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    productSlug = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    categoryId = table.Column<int>(type: "int", nullable: true),
                    productImage = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: true),
                    isDelete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    createBy = table.Column<int>(type: "int", nullable: true),
                    createTime = table.Column<DateTime>(type: "date", nullable: false),
                    modifiedBy = table.Column<int>(type: "int", nullable: true),
                    modifiedTime = table.Column<DateTime>(type: "date", nullable: false),
                    deleteBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.id);
                    table.ForeignKey(
                        name: "FK_Products_AppUsers_Create",
                        column: x => x.createBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phoneNumber = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    isDelete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    createBy = table.Column<int>(type: "int", nullable: true),
                    createTime = table.Column<DateTime>(type: "date", nullable: false),
                    modifiedBy = table.Column<int>(type: "int", nullable: true),
                    modifiedTime = table.Column<DateTime>(type: "date", nullable: false),
                    deleteBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.id);
                    table.ForeignKey(
                        name: "FK_Suppliers_AppUsers_Create",
                        column: x => x.createBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttributeValues",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    attributeId = table.Column<int>(type: "int", nullable: true),
                    attributeValue = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true),
                    createBy = table.Column<int>(type: "int", nullable: true),
                    createTime = table.Column<DateTime>(type: "date", nullable: false),
                    modifiedBy = table.Column<int>(type: "int", nullable: true),
                    modifiedTime = table.Column<DateTime>(type: "date", nullable: false),
                    deleteBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeValues", x => x.id);
                    table.ForeignKey(
                        name: "FK_AttributeValues_AppUsers_Create",
                        column: x => x.createBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AttributeValues_Attributes2",
                        column: x => x.attributeId,
                        principalTable: "Attributes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerID = table.Column<int>(type: "int", nullable: true),
                    invoiceDate = table.Column<DateTime>(type: "date", nullable: true),
                    totalPrice = table.Column<double>(type: "float", nullable: true),
                    paymentStatus = table.Column<int>(type: "int", nullable: true),
                    paymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    isDelete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    createBy = table.Column<int>(type: "int", nullable: true),
                    createTime = table.Column<DateTime>(type: "date", nullable: false),
                    modifiedBy = table.Column<int>(type: "int", nullable: true),
                    modifiedTime = table.Column<DateTime>(type: "date", nullable: false),
                    deleteBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.id);
                    table.ForeignKey(
                        name: "FK_Invoices_AppUsers_Create",
                        column: x => x.createBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Invoices_Customers",
                        column: x => x.customerID,
                        principalTable: "Customers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ProductBatches",
                columns: table => new
                {
                    productId = table.Column<int>(type: "int", nullable: false),
                    batchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBatches", x => new { x.productId, x.batchId });
                    table.ForeignKey(
                        name: "FK_ProductBatches_Batches",
                        column: x => x.batchId,
                        principalTable: "Batches",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ProductBatches_Products",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "productCategories",
                columns: table => new
                {
                    productId = table.Column<int>(type: "int", nullable: false),
                    categoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productCategories", x => new { x.productId, x.categoryId });
                    table.ForeignKey(
                        name: "FK_productCategories_Categories",
                        column: x => x.categoryId,
                        principalTable: "Categories",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_productCategories_Products",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ProductCoupons",
                columns: table => new
                {
                    productId = table.Column<int>(type: "int", nullable: false),
                    couponId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCoupons", x => new { x.productId, x.couponId });
                    table.ForeignKey(
                        name: "FK_ProductCoupons_Coupons",
                        column: x => x.couponId,
                        principalTable: "Coupons",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ProductCoupons_Products",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "StockIns",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    supplierId = table.Column<int>(type: "int", nullable: true),
                    entryDate = table.Column<DateTime>(type: "date", nullable: true),
                    totalOrderValue = table.Column<double>(type: "float", nullable: true),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isDelete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    createBy = table.Column<int>(type: "int", nullable: true),
                    createTime = table.Column<DateTime>(type: "date", nullable: false),
                    modifiedBy = table.Column<int>(type: "int", nullable: true),
                    modifiedTime = table.Column<DateTime>(type: "date", nullable: false),
                    deleteBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockIns", x => x.id);
                    table.ForeignKey(
                        name: "FK_StockIns_AppUsers_Create",
                        column: x => x.createBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StockIns_Suppliers",
                        column: x => x.supplierId,
                        principalTable: "Suppliers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Variants",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    buyingPrice = table.Column<double>(type: "float", nullable: true),
                    salePrice = table.Column<double>(type: "float", nullable: true),
                    attributeValueId = table.Column<int>(type: "int", nullable: true),
                    productId = table.Column<int>(type: "int", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: true),
                    sku = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    imageProductVariant = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    isDelete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    createBy = table.Column<int>(type: "int", nullable: true),
                    createTime = table.Column<DateTime>(type: "date", nullable: false),
                    modifiedBy = table.Column<int>(type: "int", nullable: true),
                    modifiedTime = table.Column<DateTime>(type: "date", nullable: false),
                    deleteBy = table.Column<int>(type: "int", nullable: true)
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
                name: "InvoiceDetails",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productId = table.Column<int>(type: "int", nullable: false),
                    variantId = table.Column<int>(type: "int", nullable: true),
                    invoiceId = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: true),
                    unitPrice = table.Column<double>(type: "float", nullable: true),
                    totalPrice = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetails", x => x.id);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_Invoices",
                        column: x => x.invoiceId,
                        principalTable: "Invoices",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_Products",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_Variants",
                        column: x => x.variantId,
                        principalTable: "Variants",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "StockInDetails",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    productId = table.Column<int>(type: "int", nullable: true),
                    variantId = table.Column<int>(type: "int", nullable: true),
                    stockInId = table.Column<int>(type: "int", nullable: true),
                    price = table.Column<double>(type: "float", nullable: true),
                    quantityReceived = table.Column<int>(type: "int", nullable: true),
                    unitPriceReceived = table.Column<double>(type: "float", nullable: true),
                    totalValueReceived = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockInDetails", x => x.id);
                    table.ForeignKey(
                        name: "FK_StockInDetails_Products",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_StockInDetails_StockIns",
                        column: x => x.stockInId,
                        principalTable: "StockIns",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_StockInDetails_Variants",
                        column: x => x.variantId,
                        principalTable: "Variants",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "UnitConversions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    unitName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: true),
                    productId = table.Column<int>(type: "int", nullable: true),
                    variantId = table.Column<int>(type: "int", nullable: true),
                    isDelete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    createBy = table.Column<int>(type: "int", nullable: true),
                    createTime = table.Column<DateTime>(type: "date", nullable: false),
                    modifiedBy = table.Column<int>(type: "int", nullable: true),
                    modifiedTime = table.Column<DateTime>(type: "date", nullable: false),
                    deleteBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitConversions", x => x.id);
                    table.ForeignKey(
                        name: "FK_UnitConversions_AppUsers_Create",
                        column: x => x.createBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UnitConversions_Products",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_UnitConversions_Variants",
                        column: x => x.variantId,
                        principalTable: "Variants",
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
                name: "IX_Attributes_createBy",
                table: "Attributes",
                column: "createBy");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValues_attributeId",
                table: "AttributeValues",
                column: "attributeId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValues_createBy",
                table: "AttributeValues",
                column: "createBy");

            migrationBuilder.CreateIndex(
                name: "IX_Batches_createBy",
                table: "Batches",
                column: "createBy");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_createBy",
                table: "Categories",
                column: "createBy");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_parentId",
                table: "Categories",
                column: "parentId");

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_createBy",
                table: "Coupons",
                column: "createBy");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_createBy",
                table: "Customers",
                column: "createBy");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_membershipTypeId",
                table: "Customers",
                column: "membershipTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_invoiceId",
                table: "InvoiceDetails",
                column: "invoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_productId",
                table: "InvoiceDetails",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_variantId",
                table: "InvoiceDetails",
                column: "variantId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_createBy",
                table: "Invoices",
                column: "createBy");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_customerID",
                table: "Invoices",
                column: "customerID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductBatches_batchId",
                table: "ProductBatches",
                column: "batchId");

            migrationBuilder.CreateIndex(
                name: "IX_productCategories_categoryId",
                table: "productCategories",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCoupons_couponId",
                table: "ProductCoupons",
                column: "couponId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_createBy",
                table: "Products",
                column: "createBy");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StockInDetails_productId",
                table: "StockInDetails",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_StockInDetails_stockInId",
                table: "StockInDetails",
                column: "stockInId");

            migrationBuilder.CreateIndex(
                name: "IX_StockInDetails_variantId",
                table: "StockInDetails",
                column: "variantId");

            migrationBuilder.CreateIndex(
                name: "IX_StockIns_createBy",
                table: "StockIns",
                column: "createBy");

            migrationBuilder.CreateIndex(
                name: "IX_StockIns_supplierId",
                table: "StockIns",
                column: "supplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_createBy",
                table: "Suppliers",
                column: "createBy");

            migrationBuilder.CreateIndex(
                name: "IX_UnitConversions_createBy",
                table: "UnitConversions",
                column: "createBy");

            migrationBuilder.CreateIndex(
                name: "IX_UnitConversions_productId",
                table: "UnitConversions",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitConversions_variantId",
                table: "UnitConversions",
                column: "variantId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "InvoiceDetails");

            migrationBuilder.DropTable(
                name: "ProductBatches");

            migrationBuilder.DropTable(
                name: "productCategories");

            migrationBuilder.DropTable(
                name: "ProductCoupons");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "StockInDetails");

            migrationBuilder.DropTable(
                name: "UnitConversions");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "VariantBatches");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Coupons");

            migrationBuilder.DropTable(
                name: "StockIns");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Variants");

            migrationBuilder.DropTable(
                name: "Batches");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "AttributeValues");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "MemberShipTypes");

            migrationBuilder.DropTable(
                name: "Attributes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
