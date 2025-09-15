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
                    { 1, 8, "Project A", 0 },
                    { 2, 6, "Project B", 0 }
                });

            migrationBuilder.InsertData(
                table: "TaskItems",
                columns: new[] { "Id", "Description", "DeveloperId", "EstimatedHours", "ProjectId", "Status", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "Design database schema", 2, 4, 1, 3, "Design DB", null },
                    { 2, "Setup backend API", 3, 6, 1, 1, "API Setup", null }
                });

            migrationBuilder.InsertData(
                table: "ExtensionRequests",
                columns: new[] { "Id", "DeveloperId", "ExtraHours", "Justification", "RequestDate", "Status", "TaskItemId", "UserId" },
                values: new object[,]
                {
                    { 1, 2, 2, "Need more time to finalize design", new DateTime(2025, 9, 15, 18, 13, 31, 108, DateTimeKind.Local).AddTicks(9465), 0, 1, null },
                    { 2, 3, 1, "API dependencies delay", new DateTime(2025, 9, 15, 18, 13, 31, 108, DateTimeKind.Local).AddTicks(9477), 0, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Timesheets",
                columns: new[] { "Id", "ApprovalStatus", "DeveloperId", "HoursWorked", "SubmissionDate", "Submitted", "TaskItemId" },
                values: new object[,]
                {
                    { 1, 0, 2, 2m, null, false, 1 },
                    { 2, 0, 3, 3m, null, false, 2 }
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
                keyValue: 2);

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
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
