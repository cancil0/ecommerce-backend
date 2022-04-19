using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "entity");

            migrationBuilder.EnsureSchema(
                name: "system");

            migrationBuilder.CreateTable(
                name: "api",
                schema: "system",
                columns: table => new
                {
                    apiid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    apiroute = table.Column<string>(type: "varchar", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_api", x => x.apiid);
                    table.UniqueConstraint("AK_api_apiroute", x => x.apiroute);
                },
                comment: "Holds api");

            migrationBuilder.CreateTable(
                name: "apilog",
                schema: "system",
                columns: table => new
                {
                    apilogid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    username = table.Column<string>(type: "text", nullable: false),
                    statuscode = table.Column<decimal>(type: "numeric(3)", precision: 3, nullable: false),
                    method = table.Column<string>(type: "varchar", nullable: false),
                    servicename = table.Column<string>(type: "varchar", nullable: false),
                    routeurl = table.Column<string>(type: "varchar", nullable: false),
                    request = table.Column<string>(type: "text", nullable: true),
                    response = table.Column<string>(type: "text", nullable: true),
                    duration = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    createddate = table.Column<decimal>(type: "numeric", nullable: false),
                    createdtime = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_apilog", x => x.apilogid);
                },
                comment: "Holds api logs");

            migrationBuilder.CreateTable(
                name: "category",
                schema: "entity",
                columns: table => new
                {
                    categoryid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    parentcategoryid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.categoryid);
                    table.ForeignKey(
                        name: "FK_category_category_parentcategoryid",
                        column: x => x.parentcategoryid,
                        principalSchema: "entity",
                        principalTable: "category",
                        principalColumn: "categoryid");
                },
                comment: "Holds categories");

            migrationBuilder.CreateTable(
                name: "role",
                schema: "system",
                columns: table => new
                {
                    roleid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    rolename = table.Column<string>(type: "varchar", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.roleid);
                    table.UniqueConstraint("AK_role_rolename", x => x.rolename);
                },
                comment: "Holds roles");

            migrationBuilder.CreateTable(
                name: "user",
                schema: "entity",
                columns: table => new
                {
                    userid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    surname = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    username = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "varchar", maxLength: 75, nullable: false),
                    mobileno = table.Column<string>(type: "varchar", nullable: false),
                    gender = table.Column<string>(type: "varchar", nullable: true),
                    birthdate = table.Column<decimal>(type: "numeric(8)", precision: 8, nullable: false),
                    password = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false),
                    createddate = table.Column<decimal>(type: "numeric", nullable: false),
                    createdtime = table.Column<decimal>(type: "numeric", nullable: false),
                    createdby = table.Column<string>(type: "varchar", nullable: true),
                    updateddate = table.Column<decimal>(type: "numeric", nullable: true),
                    updatedtime = table.Column<decimal>(type: "numeric", nullable: true),
                    updatedby = table.Column<string>(type: "varchar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.userid);
                },
                comment: "Holds user's information");

            migrationBuilder.CreateTable(
                name: "product",
                schema: "entity",
                columns: table => new
                {
                    productid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    name = table.Column<string>(type: "varchar", maxLength: 250, nullable: false),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false),
                    createddate = table.Column<decimal>(type: "numeric", nullable: false),
                    createdtime = table.Column<decimal>(type: "numeric", nullable: false),
                    createdby = table.Column<string>(type: "varchar", nullable: true),
                    updateddate = table.Column<decimal>(type: "numeric", nullable: true),
                    updatedtime = table.Column<decimal>(type: "numeric", nullable: true),
                    updatedby = table.Column<string>(type: "varchar", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.productid);
                    table.ForeignKey(
                        name: "FK_product_category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "entity",
                        principalTable: "category",
                        principalColumn: "categoryid");
                },
                comment: "Holds products");

            migrationBuilder.CreateTable(
                name: "apirole",
                schema: "system",
                columns: table => new
                {
                    apiid = table.Column<Guid>(type: "uuid", nullable: false),
                    roleid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_apirole", x => new { x.apiid, x.roleid });
                    table.ForeignKey(
                        name: "FK_apirole_api_apiid",
                        column: x => x.apiid,
                        principalSchema: "system",
                        principalTable: "api",
                        principalColumn: "apiid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_apirole_role_roleid",
                        column: x => x.roleid,
                        principalSchema: "system",
                        principalTable: "role",
                        principalColumn: "roleid",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Holds api's roles");

            migrationBuilder.CreateTable(
                name: "address",
                schema: "entity",
                columns: table => new
                {
                    addressid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    addresstype = table.Column<string>(type: "varchar", maxLength: 1, nullable: false),
                    country = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    province = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    district = table.Column<string>(type: "varchar", maxLength: 75, nullable: false),
                    addressinfo = table.Column<string>(type: "varchar", maxLength: 75, nullable: false),
                    mobileno = table.Column<string>(type: "varchar", maxLength: 13, nullable: false),
                    isdefault = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    createddate = table.Column<decimal>(type: "numeric", nullable: false),
                    createdtime = table.Column<decimal>(type: "numeric", nullable: false),
                    createdby = table.Column<string>(type: "varchar", nullable: true),
                    updateddate = table.Column<decimal>(type: "numeric", nullable: true),
                    updatedtime = table.Column<decimal>(type: "numeric", nullable: true),
                    updatedby = table.Column<string>(type: "varchar", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.addressid);
                    table.ForeignKey(
                        name: "FK_address_user_UserId",
                        column: x => x.UserId,
                        principalSchema: "entity",
                        principalTable: "user",
                        principalColumn: "userid");
                },
                comment: "Holds users and purchases adresses");

            migrationBuilder.CreateTable(
                name: "cart",
                schema: "entity",
                columns: table => new
                {
                    cartid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    userid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cart", x => x.cartid);
                    table.ForeignKey(
                        name: "FK_cart_user_userid",
                        column: x => x.userid,
                        principalSchema: "entity",
                        principalTable: "user",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Holds user's cart");

            migrationBuilder.CreateTable(
                name: "userrole",
                schema: "system",
                columns: table => new
                {
                    userid = table.Column<Guid>(type: "uuid", nullable: false),
                    roleid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userrole", x => new { x.userid, x.roleid });
                    table.ForeignKey(
                        name: "FK_userrole_role_roleid",
                        column: x => x.roleid,
                        principalSchema: "system",
                        principalTable: "role",
                        principalColumn: "roleid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userrole_user_userid",
                        column: x => x.userid,
                        principalSchema: "entity",
                        principalTable: "user",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Holds user's roles");

            migrationBuilder.CreateTable(
                name: "media",
                schema: "entity",
                columns: table => new
                {
                    mediaid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    name = table.Column<string>(type: "varchar", maxLength: 250, nullable: false),
                    path = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    order = table.Column<decimal>(type: "numeric(2)", precision: 2, nullable: false),
                    createddate = table.Column<decimal>(type: "numeric", nullable: false),
                    createdtime = table.Column<decimal>(type: "numeric", nullable: false),
                    createdby = table.Column<string>(type: "varchar", nullable: true),
                    updateddate = table.Column<decimal>(type: "numeric", nullable: true),
                    updatedtime = table.Column<decimal>(type: "numeric", nullable: true),
                    updatedby = table.Column<string>(type: "varchar", nullable: true),
                    IsCoverPhoto = table.Column<bool>(type: "boolean", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_media", x => x.mediaid);
                    table.ForeignKey(
                        name: "FK_media_product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "entity",
                        principalTable: "product",
                        principalColumn: "productid");
                },
                comment: "Holds medias");

            migrationBuilder.CreateTable(
                name: "merchant",
                schema: "entity",
                columns: table => new
                {
                    merchantid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    merchantname = table.Column<string>(type: "varchar", maxLength: 250, nullable: false),
                    merchantpoint = table.Column<decimal>(type: "numeric(2,1)", precision: 2, scale: 1, nullable: false),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false),
                    createddate = table.Column<decimal>(type: "numeric", nullable: false),
                    createdtime = table.Column<decimal>(type: "numeric", nullable: false),
                    createdby = table.Column<string>(type: "varchar", nullable: true),
                    updateddate = table.Column<decimal>(type: "numeric", nullable: true),
                    updatedtime = table.Column<decimal>(type: "numeric", nullable: true),
                    updatedby = table.Column<string>(type: "varchar", nullable: true),
                    AddressId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_merchant", x => x.merchantid);
                    table.ForeignKey(
                        name: "FK_merchant_address_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "entity",
                        principalTable: "address",
                        principalColumn: "addressid");
                },
                comment: "Holds merchants");

            migrationBuilder.CreateTable(
                name: "purchase",
                schema: "entity",
                columns: table => new
                {
                    purchaseid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    totalprice = table.Column<decimal>(type: "numeric(15,2)", precision: 15, scale: 2, nullable: false),
                    createddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updateddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    AddressId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchase", x => x.purchaseid);
                    table.ForeignKey(
                        name: "FK_purchase_address_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "entity",
                        principalTable: "address",
                        principalColumn: "addressid");
                    table.ForeignKey(
                        name: "FK_purchase_user_UserId",
                        column: x => x.UserId,
                        principalSchema: "entity",
                        principalTable: "user",
                        principalColumn: "userid");
                },
                comment: "Holds purschases");

            migrationBuilder.CreateTable(
                name: "cart_product",
                schema: "entity",
                columns: table => new
                {
                    cartid = table.Column<Guid>(type: "uuid", nullable: false),
                    productid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cart_product", x => new { x.cartid, x.productid });
                    table.ForeignKey(
                        name: "FK_cart_product_cart_cartid",
                        column: x => x.cartid,
                        principalSchema: "entity",
                        principalTable: "cart",
                        principalColumn: "cartid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cart_product_product_productid",
                        column: x => x.productid,
                        principalSchema: "entity",
                        principalTable: "product",
                        principalColumn: "productid",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Holds cart's products");

            migrationBuilder.CreateTable(
                name: "productdetail",
                schema: "entity",
                columns: table => new
                {
                    productdetailid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    count = table.Column<decimal>(type: "numeric(10)", precision: 10, nullable: false),
                    price = table.Column<decimal>(type: "numeric(15,2)", precision: 15, scale: 2, nullable: false),
                    detail = table.Column<string>(type: "varchar", maxLength: 4000, nullable: false),
                    color = table.Column<string>(type: "varchar", maxLength: 50, nullable: true),
                    size = table.Column<decimal>(type: "numeric", maxLength: 250, nullable: true),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: true),
                    MerchantId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productdetail", x => x.productdetailid);
                    table.ForeignKey(
                        name: "FK_productdetail_merchant_MerchantId",
                        column: x => x.MerchantId,
                        principalSchema: "entity",
                        principalTable: "merchant",
                        principalColumn: "merchantid");
                    table.ForeignKey(
                        name: "FK_productdetail_product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "entity",
                        principalTable: "product",
                        principalColumn: "productid");
                },
                comment: "Holds product's details");

            migrationBuilder.CreateTable(
                name: "purchased_product",
                schema: "entity",
                columns: table => new
                {
                    purchaseid = table.Column<Guid>(type: "uuid", nullable: false),
                    productid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchased_product", x => new { x.productid, x.purchaseid });
                    table.ForeignKey(
                        name: "FK_purchased_product_product_productid",
                        column: x => x.productid,
                        principalSchema: "entity",
                        principalTable: "product",
                        principalColumn: "productid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_purchased_product_purchase_purchaseid",
                        column: x => x.purchaseid,
                        principalSchema: "entity",
                        principalTable: "purchase",
                        principalColumn: "purchaseid",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Holds pursches's products");

            migrationBuilder.CreateIndex(
                name: "IX_address_UserId",
                schema: "entity",
                table: "address",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_apirole_roleid",
                schema: "system",
                table: "apirole",
                column: "roleid");

            migrationBuilder.CreateIndex(
                name: "IX_cart_userid",
                schema: "entity",
                table: "cart",
                column: "userid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cart_product_productid",
                schema: "entity",
                table: "cart_product",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_category_parentcategoryid",
                schema: "entity",
                table: "category",
                column: "parentcategoryid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_media_ProductId",
                schema: "entity",
                table: "media",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_merchant_AddressId",
                schema: "entity",
                table: "merchant",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_product_CategoryId",
                schema: "entity",
                table: "product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_productdetail_MerchantId",
                schema: "entity",
                table: "productdetail",
                column: "MerchantId");

            migrationBuilder.CreateIndex(
                name: "IX_productdetail_ProductId",
                schema: "entity",
                table: "productdetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_purchase_AddressId",
                schema: "entity",
                table: "purchase",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_purchase_UserId",
                schema: "entity",
                table: "purchase",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_purchased_product_purchaseid",
                schema: "entity",
                table: "purchased_product",
                column: "purchaseid");

            migrationBuilder.CreateIndex(
                name: "IX_userrole_roleid",
                schema: "system",
                table: "userrole",
                column: "roleid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "apilog",
                schema: "system");

            migrationBuilder.DropTable(
                name: "apirole",
                schema: "system");

            migrationBuilder.DropTable(
                name: "cart_product",
                schema: "entity");

            migrationBuilder.DropTable(
                name: "media",
                schema: "entity");

            migrationBuilder.DropTable(
                name: "productdetail",
                schema: "entity");

            migrationBuilder.DropTable(
                name: "purchased_product",
                schema: "entity");

            migrationBuilder.DropTable(
                name: "userrole",
                schema: "system");

            migrationBuilder.DropTable(
                name: "api",
                schema: "system");

            migrationBuilder.DropTable(
                name: "cart",
                schema: "entity");

            migrationBuilder.DropTable(
                name: "merchant",
                schema: "entity");

            migrationBuilder.DropTable(
                name: "product",
                schema: "entity");

            migrationBuilder.DropTable(
                name: "purchase",
                schema: "entity");

            migrationBuilder.DropTable(
                name: "role",
                schema: "system");

            migrationBuilder.DropTable(
                name: "category",
                schema: "entity");

            migrationBuilder.DropTable(
                name: "address",
                schema: "entity");

            migrationBuilder.DropTable(
                name: "user",
                schema: "entity");
        }
    }
}
