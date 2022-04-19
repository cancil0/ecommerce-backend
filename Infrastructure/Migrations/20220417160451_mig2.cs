using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_category_parentcategoryid",
                schema: "entity",
                table: "category");

            migrationBuilder.AlterColumn<decimal>(
                name: "birthdate",
                schema: "entity",
                table: "user",
                type: "numeric(8)",
                precision: 8,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(8,0)",
                oldPrecision: 8);

            migrationBuilder.AlterColumn<decimal>(
                name: "count",
                schema: "entity",
                table: "productdetail",
                type: "numeric(10)",
                precision: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,0)",
                oldPrecision: 10);

            migrationBuilder.AlterColumn<decimal>(
                name: "order",
                schema: "entity",
                table: "media",
                type: "numeric(2)",
                precision: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(2,0)",
                oldPrecision: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "statuscode",
                schema: "system",
                table: "apilog",
                type: "numeric(3)",
                precision: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(3,0)",
                oldPrecision: 3);

            migrationBuilder.CreateIndex(
                name: "IX_category_parentcategoryid",
                schema: "entity",
                table: "category",
                column: "parentcategoryid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_category_parentcategoryid",
                schema: "entity",
                table: "category");

            migrationBuilder.AlterColumn<decimal>(
                name: "birthdate",
                schema: "entity",
                table: "user",
                type: "numeric(8,0)",
                precision: 8,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(8)",
                oldPrecision: 8);

            migrationBuilder.AlterColumn<decimal>(
                name: "count",
                schema: "entity",
                table: "productdetail",
                type: "numeric(10,0)",
                precision: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(10)",
                oldPrecision: 10);

            migrationBuilder.AlterColumn<decimal>(
                name: "order",
                schema: "entity",
                table: "media",
                type: "numeric(2,0)",
                precision: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(2)",
                oldPrecision: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "statuscode",
                schema: "system",
                table: "apilog",
                type: "numeric(3,0)",
                precision: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(3)",
                oldPrecision: 3);

            migrationBuilder.CreateIndex(
                name: "IX_category_parentcategoryid",
                schema: "entity",
                table: "category",
                column: "parentcategoryid",
                unique: true);
        }
    }
}
