using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class mig4 : Migration
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

            migrationBuilder.AddColumn<decimal>(
                name: "clickcount",
                schema: "entity",
                table: "productdetail",
                type: "numeric(20,0)",
                maxLength: 250,
                nullable: false,
                defaultValue: 0m)
                .Annotation("Relational:ColumnOrder", 7);

            migrationBuilder.AddColumn<decimal>(
                name: "purchasecount",
                schema: "entity",
                table: "productdetail",
                type: "numeric(20,0)",
                maxLength: 250,
                nullable: false,
                defaultValue: 0m)
                .Annotation("Relational:ColumnOrder", 8);

            migrationBuilder.AlterColumn<decimal>(
                name: "updatedtime",
                schema: "entity",
                table: "merchant",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 11)
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
                .Annotation("Relational:ColumnOrder", 10)
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
                .Annotation("Relational:ColumnOrder", 12)
                .OldAnnotation("Relational:ColumnOrder", 11);

            migrationBuilder.AlterColumn<decimal>(
                name: "registrationno",
                schema: "entity",
                table: "merchant",
                type: "numeric(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(20,0)")
                .Annotation("Relational:ColumnOrder", 5)
                .OldAnnotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<bool>(
                name: "isdeleted",
                schema: "entity",
                table: "merchant",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean")
                .Annotation("Relational:ColumnOrder", 6)
                .OldAnnotation("Relational:ColumnOrder", 5);

            migrationBuilder.AlterColumn<decimal>(
                name: "feedbackcount",
                schema: "entity",
                table: "merchant",
                type: "numeric(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(20,0)")
                .Annotation("Relational:ColumnOrder", 4)
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "createdtime",
                schema: "entity",
                table: "merchant",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric")
                .Annotation("Relational:ColumnOrder", 8)
                .OldAnnotation("Relational:ColumnOrder", 7);

            migrationBuilder.AlterColumn<decimal>(
                name: "createddate",
                schema: "entity",
                table: "merchant",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric")
                .Annotation("Relational:ColumnOrder", 7)
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
                .Annotation("Relational:ColumnOrder", 9)
                .OldAnnotation("Relational:ColumnOrder", 8);

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

            migrationBuilder.CreateTable(
                name: "userdefault",
                schema: "entity",
                columns: table => new
                {
                    userdefaultid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    userid = table.Column<Guid>(type: "uuid", nullable: false),
                    cultereinfo = table.Column<string>(type: "varchar", nullable: false),
                    theme = table.Column<string>(type: "varchar", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userdefault", x => x.userdefaultid);
                    table.ForeignKey(
                        name: "FK_userdefault_user_userid",
                        column: x => x.userid,
                        principalSchema: "entity",
                        principalTable: "user",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_userdefault_userid",
                schema: "entity",
                table: "userdefault",
                column: "userid",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "userdefault",
                schema: "entity");

            migrationBuilder.DropColumn(
                name: "clickcount",
                schema: "entity",
                table: "productdetail");

            migrationBuilder.DropColumn(
                name: "purchasecount",
                schema: "entity",
                table: "productdetail");

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
                table: "merchant",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 10)
                .OldAnnotation("Relational:ColumnOrder", 11);

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
                .OldAnnotation("Relational:ColumnOrder", 10);

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
                .OldAnnotation("Relational:ColumnOrder", 12);

            migrationBuilder.AlterColumn<decimal>(
                name: "registrationno",
                schema: "entity",
                table: "merchant",
                type: "numeric(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(20,0)")
                .Annotation("Relational:ColumnOrder", 4)
                .OldAnnotation("Relational:ColumnOrder", 5);

            migrationBuilder.AlterColumn<bool>(
                name: "isdeleted",
                schema: "entity",
                table: "merchant",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean")
                .Annotation("Relational:ColumnOrder", 5)
                .OldAnnotation("Relational:ColumnOrder", 6);

            migrationBuilder.AlterColumn<decimal>(
                name: "feedbackcount",
                schema: "entity",
                table: "merchant",
                type: "numeric(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(20,0)")
                .Annotation("Relational:ColumnOrder", 3)
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
                .OldAnnotation("Relational:ColumnOrder", 8);

            migrationBuilder.AlterColumn<decimal>(
                name: "createddate",
                schema: "entity",
                table: "merchant",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric")
                .Annotation("Relational:ColumnOrder", 6)
                .OldAnnotation("Relational:ColumnOrder", 7);

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
                .OldAnnotation("Relational:ColumnOrder", 9);

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
