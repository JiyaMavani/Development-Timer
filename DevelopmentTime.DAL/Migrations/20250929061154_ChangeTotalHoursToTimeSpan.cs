using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevelopmentTimer.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTotalHoursToTimeSpan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "TotalHoursTemp",
                table: "TaskItems",
                type: "time",
                nullable: false,
                defaultValue: TimeSpan.Zero);

            migrationBuilder.Sql(
                "UPDATE TaskItems SET TotalHoursTemp = DATEADD(HOUR, TotalHours, 0)");

            migrationBuilder.DropColumn(
                name: "TotalHours",
                table: "TaskItems");

            migrationBuilder.RenameColumn(
                name: "TotalHoursTemp",
                table: "TaskItems",
                newName: "TotalHours");

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "TotalHours",
                value: TimeSpan.FromHours(2));

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "TotalHours",
                value: TimeSpan.FromHours(3));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalHoursTemp",
                table: "TaskItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.Sql(
                "UPDATE TaskItems SET TotalHoursTemp = DATEPART(HOUR, TotalHours)");

            migrationBuilder.DropColumn(
                name: "TotalHours",
                table: "TaskItems");

            migrationBuilder.RenameColumn(
                name: "TotalHour",
                table: "TaskItems",
                newName: "TotalHour");

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "TotalHours",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "TotalHours",
                value: 3);
        }
    }
}
