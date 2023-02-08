using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductReview.Server.Data.Migrations
{
    public partial class AddApplicationTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Genres",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateUploaded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateUploaded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateUpdated", "DateUploaded" },
                values: new object[] { new DateTime(2023, 2, 8, 21, 35, 41, 112, DateTimeKind.Local).AddTicks(3796), new DateTime(2023, 2, 8, 21, 35, 41, 111, DateTimeKind.Local).AddTicks(7345) });

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateUpdated", "DateUploaded" },
                values: new object[] { new DateTime(2023, 2, 8, 21, 35, 41, 112, DateTimeKind.Local).AddTicks(4333), new DateTime(2023, 2, 8, 21, 35, 41, 112, DateTimeKind.Local).AddTicks(4330) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Genres",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateUpdated", "DateUploaded" },
                values: new object[] { new DateTime(2023, 1, 28, 14, 12, 1, 31, DateTimeKind.Local).AddTicks(3459), new DateTime(2023, 1, 28, 14, 12, 1, 30, DateTimeKind.Local).AddTicks(6390) });

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateUpdated", "DateUploaded" },
                values: new object[] { new DateTime(2023, 1, 28, 14, 12, 1, 31, DateTimeKind.Local).AddTicks(4978), new DateTime(2023, 1, 28, 14, 12, 1, 31, DateTimeKind.Local).AddTicks(4969) });
        }
    }
}
