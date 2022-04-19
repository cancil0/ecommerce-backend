using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "updatedtime",
                schema: "entity",
                table: "product",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 10)
                .OldAnnotation("Relational:ColumnOrder", 8);

            migrationBuilder.AlterColumn<decimal>(
                name: "updateddate",
                schema: "entity",
                table: "product",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 9)
                .OldAnnotation("Relational:ColumnOrder", 7);

            migrationBuilder.AlterColumn<string>(
                name: "updatedby",
                schema: "entity",
                table: "product",
                type: "varchar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 11)
                .OldAnnotation("Relational:ColumnOrder", 9);

            migrationBuilder.AlterColumn<bool>(
                name: "isdeleted",
                schema: "entity",
                table: "product",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean")
                .Annotation("Relational:ColumnOrder", 5)
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "createdtime",
                schema: "entity",
                table: "product",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric")
                .Annotation("Relational:ColumnOrder", 7)
                .OldAnnotation("Relational:ColumnOrder", 5);

            migrationBuilder.AlterColumn<decimal>(
                name: "createddate",
                schema: "entity",
                table: "product",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric")
                .Annotation("Relational:ColumnOrder", 6)
                .OldAnnotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<string>(
                name: "createdby",
                schema: "entity",
                table: "product",
                type: "varchar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 8)
                .OldAnnotation("Relational:ColumnOrder", 6);

            migrationBuilder.AddColumn<string>(
                name: "brand",
                schema: "entity",
                table: "product",
                type: "varchar",
                maxLength: 250,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 4);

            migrationBuilder.AddColumn<string>(
                name: "model",
                schema: "entity",
                table: "product",
                type: "varchar",
                maxLength: 250,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "updatedtime",
                schema: "entity",
                table: "merchant",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 10)
                .OldAnnotation("Relational:ColumnOrder", 9);

            migrationBuilder.AlterColumn<decimal>(
                name: "updateddate",
                schema: "entity",
                table: "merchant",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 9)
                .OldAnnotation("Relational:ColumnOrder", 8);

            migrationBuilder.AlterColumn<string>(
                name: "updatedby",
                schema: "entity",
                table: "merchant",
                type: "varchar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 11)
                .OldAnnotation("Relational:ColumnOrder", 10);

            migrationBuilder.AlterColumn<bool>(
                name: "isdeleted",
                schema: "entity",
                table: "merchant",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean")
                .Annotation("Relational:ColumnOrder", 5)
                .OldAnnotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<decimal>(
                name: "createdtime",
                schema: "entity",
                table: "merchant",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric")
                .Annotation("Relational:ColumnOrder", 7)
                .OldAnnotation("Relational:ColumnOrder", 6);

            migrationBuilder.AlterColumn<decimal>(
                name: "createddate",
                schema: "entity",
                table: "merchant",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric")
                .Annotation("Relational:ColumnOrder", 6)
                .OldAnnotation("Relational:ColumnOrder", 5);

            migrationBuilder.AlterColumn<string>(
                name: "createdby",
                schema: "entity",
                table: "merchant",
                type: "varchar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 8)
                .OldAnnotation("Relational:ColumnOrder", 7);

            migrationBuilder.AddColumn<decimal>(
                name: "feedbackcount",
                schema: "entity",
                table: "merchant",
                type: "numeric(20,0)",
                nullable: false,
                defaultValue: 0m)
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AddColumn<decimal>(
                name: "registrationno",
                schema: "entity",
                table: "merchant",
                type: "numeric(20,0)",
                nullable: false,
                defaultValue: 0m)
                .Annotation("Relational:ColumnOrder", 4);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "brand",
                schema: "entity",
                table: "product");

            migrationBuilder.DropColumn(
                name: "model",
                schema: "entity",
                table: "product");

            migrationBuilder.DropColumn(
                name: "feedbackcount",
                schema: "entity",
                table: "merchant");

            migrationBuilder.DropColumn(
                name: "registrationno",
                schema: "entity",
                table: "merchant");

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
                name: "updatedtime",
                schema: "entity",
                table: "product",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 8)
                .OldAnnotation("Relational:ColumnOrder", 10);

            migrationBuilder.AlterColumn<decimal>(
                name: "updateddate",
                schema: "entity",
                table: "product",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 7)
                .OldAnnotation("Relational:ColumnOrder", 9);

            migrationBuilder.AlterColumn<string>(
                name: "updatedby",
                schema: "entity",
                table: "product",
                type: "varchar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 9)
                .OldAnnotation("Relational:ColumnOrder", 11);

            migrationBuilder.AlterColumn<bool>(
                name: "isdeleted",
                schema: "entity",
                table: "product",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean")
                .Annotation("Relational:ColumnOrder", 3)
                .OldAnnotation("Relational:ColumnOrder", 5);

            migrationBuilder.AlterColumn<decimal>(
                name: "createdtime",
                schema: "entity",
                table: "product",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric")
                .Annotation("Relational:ColumnOrder", 5)
                .OldAnnotation("Relational:ColumnOrder", 7);

            migrationBuilder.AlterColumn<decimal>(
                name: "createddate",
                schema: "entity",
                table: "product",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric")
                .Annotation("Relational:ColumnOrder", 4)
                .OldAnnotation("Relational:ColumnOrder", 6);

            migrationBuilder.AlterColumn<string>(
                name: "createdby",
                schema: "entity",
                table: "product",
                type: "varchar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 6)
                .OldAnnotation("Relational:ColumnOrder", 8);

            migrationBuilder.AlterColumn<decimal>(
                name: "updatedtime",
                schema: "entity",
                table: "merchant",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 9)
                .OldAnnotation("Relational:ColumnOrder", 10);

            migrationBuilder.AlterColumn<decimal>(
                name: "updateddate",
                schema: "entity",
                table: "merchant",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 8)
                .OldAnnotation("Relational:ColumnOrder", 9);

            migrationBuilder.AlterColumn<string>(
                name: "updatedby",
                schema: "entity",
                table: "merchant",
                type: "varchar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 10)
                .OldAnnotation("Relational:ColumnOrder", 11);

            migrationBuilder.AlterColumn<bool>(
                name: "isdeleted",
                schema: "entity",
                table: "merchant",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean")
                .Annotation("Relational:ColumnOrder", 4)
                .OldAnnotation("Relational:ColumnOrder", 5);

            migrationBuilder.AlterColumn<decimal>(
                name: "createdtime",
                schema: "entity",
                table: "merchant",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric")
                .Annotation("Relational:ColumnOrder", 6)
                .OldAnnotation("Relational:ColumnOrder", 7);

            migrationBuilder.AlterColumn<decimal>(
                name: "createddate",
                schema: "entity",
                table: "merchant",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric")
                .Annotation("Relational:ColumnOrder", 5)
                .OldAnnotation("Relational:ColumnOrder", 6);

            migrationBuilder.AlterColumn<string>(
                name: "createdby",
                schema: "entity",
                table: "merchant",
                type: "varchar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 7)
                .OldAnnotation("Relational:ColumnOrder", 8);

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
        }
    }
}
