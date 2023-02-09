using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductReview.Server.Migrations
{
    public partial class AddedDefaultDataAndUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedBy", "DateUpdated", "DateUploaded", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2023, 2, 9, 10, 55, 5, 400, DateTimeKind.Local).AddTicks(3821), new DateTime(2023, 2, 9, 10, 55, 5, 400, DateTimeKind.Local).AddTicks(3800), "John", "System" },
                    { 2, "System", new DateTime(2023, 2, 9, 10, 55, 5, 400, DateTimeKind.Local).AddTicks(3825), new DateTime(2023, 2, 9, 10, 55, 5, 400, DateTimeKind.Local).AddTicks(3824), "Mary", "System" }
                });

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateUpdated", "DateUploaded" },
                values: new object[] { new DateTime(2023, 2, 9, 10, 55, 5, 399, DateTimeKind.Local).AddTicks(1590), new DateTime(2023, 2, 9, 10, 55, 5, 397, DateTimeKind.Local).AddTicks(4247) });

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateUpdated", "DateUploaded" },
                values: new object[] { new DateTime(2023, 2, 9, 10, 55, 5, 399, DateTimeKind.Local).AddTicks(2196), new DateTime(2023, 2, 9, 10, 55, 5, 399, DateTimeKind.Local).AddTicks(2191) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateUpdated", "DateUploaded" },
                values: new object[] { new DateTime(2023, 2, 9, 10, 47, 16, 489, DateTimeKind.Local).AddTicks(9833), new DateTime(2023, 2, 9, 10, 47, 16, 488, DateTimeKind.Local).AddTicks(1320) });

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateUpdated", "DateUploaded" },
                values: new object[] { new DateTime(2023, 2, 9, 10, 47, 16, 490, DateTimeKind.Local).AddTicks(486), new DateTime(2023, 2, 9, 10, 47, 16, 490, DateTimeKind.Local).AddTicks(480) });
        }
    }
}
