using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevelopmentTimer.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedExtensionsRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestDate",
                table: "ExtensionRequests");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ExtensionRequests");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RequestDate",
                table: "ExtensionRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ExtensionRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ExtensionRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "RequestDate", "Status" },
                values: new object[] { new DateTime(2025, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.UpdateData(
                table: "ExtensionRequests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "RequestDate", "Status" },
                values: new object[] { new DateTime(2025, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });
        }
    }
}
