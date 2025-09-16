using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DevelopmentTimer.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialSeedAllData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "MaxHoursPerDay", "Name", "Status" },
                values: new object[,]
                {
                    { 1, 7, "Project1", 1 },
                    { 2, 6, "Project2", 2 },
                    { 3, 8, "Project3", 7 }
                });

            migrationBuilder.InsertData(
                table: "TaskItems",
                columns: new[] { "Id", "Description", "DeveloperId", "EstimatedHours", "ProjectId", "Status", "Title" },
                values: new object[,]
                {
                    { 1, "Login Page Creation", 2, 2, 1, 1, "Login Page" },
                    { 2, "Register Page Creation", 2, 3, 1, 2, "Register Page" },
                    { 3, "Login Page Creation", 3, 2, 2, 1, "Login Page" },
                    { 4, "Register Page Creation", 3, 3, 2, 2, "Register Page" }
                });

            migrationBuilder.InsertData(
                table: "ExtensionRequests",
                columns: new[] { "Id", "DeveloperId", "ExtraHours", "Justification", "RequestDate", "Status", "TaskItemId" },
                values: new object[,]
                {
                    { 1, 2, 1, "To create responsive design", new DateTime(2025, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, 3, 2, "To create responsive design", new DateTime(2025, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "Timesheets",
                columns: new[] { "Id", "ApprovalStatus", "DeveloperId", "HoursWorked", "SubmissionDate", "Submitted", "TaskItemId" },
                values: new object[,]
                {
                    { 1, 3, 2, 5m, new DateTime(2025, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1 },
                    { 2, 7, 2, 4m, new DateTime(2025, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExtensionRequests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ExtensionRequests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Timesheets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Timesheets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
