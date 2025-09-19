using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DevelopmentTimer.DAL.Migrations
{
    /// <inheritdoc />
    public partial class DropTimeSheetTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Timesheets");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Timesheets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeveloperId = table.Column<int>(type: "int", nullable: false),
                    TaskItemId = table.Column<int>(type: "int", nullable: false),
                    ApprovalStatus = table.Column<int>(type: "int", nullable: false),
                    HoursWorked = table.Column<decimal>(type: "decimal(4,2)", precision: 4, scale: 2, nullable: false),
                    SubmissionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Submitted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timesheets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Timesheets_TaskItems_TaskItemId",
                        column: x => x.TaskItemId,
                        principalTable: "TaskItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Timesheets_Users_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Timesheets",
                columns: new[] { "Id", "ApprovalStatus", "DeveloperId", "HoursWorked", "SubmissionDate", "Submitted", "TaskItemId" },
                values: new object[,]
                {
                    { 1, 3, 2, 5m, new DateTime(2025, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1 },
                    { 2, 7, 2, 4m, new DateTime(2025, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Timesheets_DeveloperId",
                table: "Timesheets",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_Timesheets_TaskItemId",
                table: "Timesheets",
                column: "TaskItemId");
        }
    }
}
