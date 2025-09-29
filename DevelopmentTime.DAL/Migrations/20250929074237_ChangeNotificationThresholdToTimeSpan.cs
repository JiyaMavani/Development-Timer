using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevelopmentTimer.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNotificationThresholdToTimeSpan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "NotificationThresholdMinutes",
                value: new TimeSpan(0, 0, 10, 0, 0));

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "NotificationThresholdMinutes",
                value: new TimeSpan(0, 0, 45, 0, 0));

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "NotificationThresholdMinutes",
                value: new TimeSpan(0, 0, 30, 0, 0));

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "NotificationThresholdMinutes",
                value: new TimeSpan(0, 0, 15, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "NotificationThresholdMinutes",
                value: new TimeOnly(0, 10, 0));

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "NotificationThresholdMinutes",
                value: new TimeOnly(0, 45, 0));

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "NotificationThresholdMinutes",
                value: new TimeOnly(0, 30, 0));

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "NotificationThresholdMinutes",
                value: new TimeOnly(0, 15, 0));
        }
    }
}
