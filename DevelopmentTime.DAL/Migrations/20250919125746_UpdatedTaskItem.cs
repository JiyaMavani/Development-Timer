using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevelopmentTimer.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedTaskItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "Date",
                table: "TaskItems",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "NotificationThresholdMinutes",
                table: "TaskItems",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "TotalHours",
                table: "TaskItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "isApproved",
                table: "TaskItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "NotificationThresholdMinutes", "TotalHours", "isApproved" },
                values: new object[] { new DateOnly(1, 1, 1), new TimeOnly(0, 0, 0), 0, false });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "NotificationThresholdMinutes", "TotalHours", "isApproved" },
                values: new object[] { new DateOnly(1, 1, 1), new TimeOnly(0, 0, 0), 0, false });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "NotificationThresholdMinutes", "TotalHours", "isApproved" },
                values: new object[] { new DateOnly(1, 1, 1), new TimeOnly(0, 0, 0), 0, false });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "NotificationThresholdMinutes", "TotalHours", "isApproved" },
                values: new object[] { new DateOnly(1, 1, 1), new TimeOnly(0, 0, 0), 0, false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "TaskItems");

            migrationBuilder.DropColumn(
                name: "NotificationThresholdMinutes",
                table: "TaskItems");

            migrationBuilder.DropColumn(
                name: "TotalHours",
                table: "TaskItems");

            migrationBuilder.DropColumn(
                name: "isApproved",
                table: "TaskItems");
        }
    }
}
