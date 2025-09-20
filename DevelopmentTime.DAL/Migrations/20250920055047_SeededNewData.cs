using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevelopmentTimer.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeededNewData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalHours",
                table: "TaskItems");

            migrationBuilder.AddColumn<string>(
                name: "AssignedProjectIds",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ExtensionRequests",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExtraHours",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "Description", "NotificationThresholdMinutes" },
                values: new object[] { new DateOnly(2025, 9, 19), "This is the login page creation task with detailed description", new TimeOnly(0, 10, 0) });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "Description" },
                values: new object[] { new DateOnly(2025, 9, 18), "Develop the register page including email verification, password rules validation, and linking it with the database for new users." });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "Description", "EstimatedHours", "NotificationThresholdMinutes", "Status", "Title" },
                values: new object[] { new DateOnly(2025, 9, 20), "Implement dashboard UI to display project status, active tasks, and progress reports using charts and grids for better user insights.", 3, new TimeOnly(0, 30, 0), 3, "Dashboard" });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "Description", "EstimatedHours", "NotificationThresholdMinutes", "Status", "Title", "isApproved" },
                values: new object[] { new DateOnly(2025, 9, 21), "Design and build profile page where users can update details, change password, and manage their personal settings securely.", 4, new TimeOnly(0, 15, 0), 1, "Profile Page", false });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "AssignedProjectIds",
                value: "0");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "AssignedProjectIds",
                value: "1,2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "AssignedProjectIds",
                value: "2,3");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignedProjectIds",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "TotalHours",
                table: "TaskItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ExtensionRequests",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExtraHours",
                value: 1);

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
                columns: new[] { "Date", "Description", "TotalHours" },
                values: new object[] { new DateOnly(2025, 9, 14), "Creating the registration page with user input validations, email verification, and password rules.", 3 });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "Description", "EstimatedHours", "NotificationThresholdMinutes", "Status", "Title", "TotalHours" },
                values: new object[] { new DateOnly(2025, 9, 16), "Implement login functionality including API integration and proper error handling for Project Beta.", 2, new TimeOnly(2, 0, 0), 1, "Login Page", 2 });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "Description", "EstimatedHours", "NotificationThresholdMinutes", "Status", "Title", "TotalHours", "isApproved" },
                values: new object[] { new DateOnly(2025, 9, 12), "Implement registration functionality including validations, email service, and security checks for Project Beta.", 3, new TimeOnly(1, 0, 0), 2, "Register Page", 3, true });
        }
    }
}
