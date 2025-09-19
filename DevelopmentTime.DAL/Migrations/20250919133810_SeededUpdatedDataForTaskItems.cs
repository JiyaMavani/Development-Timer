using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevelopmentTimer.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeededUpdatedDataForTaskItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "Description", "NotificationThresholdMinutes", "TotalHours" },
                values: new object[] { new DateOnly(2025, 9, 17), "Creating the login page with username, password fields, and validation for user authentication.", new TimeOnly(1, 30, 0), 1 });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "Description", "NotificationThresholdMinutes", "TotalHours", "isApproved" },
                values: new object[] { new DateOnly(2025, 9, 14), "Creating the registration page with user input validations, email verification, and password rules.", new TimeOnly(0, 45, 0), 3, true });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "Description", "NotificationThresholdMinutes", "TotalHours" },
                values: new object[] { new DateOnly(2025, 9, 16), "Implement login functionality including API integration and proper error handling for Project Beta.", new TimeOnly(2, 0, 0), 2 });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "Description", "NotificationThresholdMinutes", "TotalHours", "isApproved" },
                values: new object[] { new DateOnly(2025, 9, 12), "Implement registration functionality including validations, email service, and security checks for Project Beta.", new TimeOnly(1, 0, 0), 3, true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "Description", "NotificationThresholdMinutes", "TotalHours" },
                values: new object[] { new DateOnly(1, 1, 1), "Login Page Creation", new TimeOnly(0, 0, 0), 0 });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "Description", "NotificationThresholdMinutes", "TotalHours", "isApproved" },
                values: new object[] { new DateOnly(1, 1, 1), "Register Page Creation", new TimeOnly(0, 0, 0), 0, false });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "Description", "NotificationThresholdMinutes", "TotalHours" },
                values: new object[] { new DateOnly(1, 1, 1), "Login Page Creation", new TimeOnly(0, 0, 0), 0 });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "Description", "NotificationThresholdMinutes", "TotalHours", "isApproved" },
                values: new object[] { new DateOnly(1, 1, 1), "Register Page Creation", new TimeOnly(0, 0, 0), 0, false });
        }
    }
}
