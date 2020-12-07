using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LecturalAPI.Migrations
{
    public partial class AddToDisciplinesFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "GPID",
                table: "Discipline",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Plan",
                table: "Discipline",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "countHoursGZ",
                table: "Discipline",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "countHoursLR",
                table: "Discipline",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "countHoursLeck",
                table: "Discipline",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "countHoursMZ",
                table: "Discipline",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "countHoursPZ",
                table: "Discipline",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "countHoursSEM",
                table: "Discipline",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "countHoursSWZ",
                table: "Discipline",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GPID",
                table: "Discipline");

            migrationBuilder.DropColumn(
                name: "Plan",
                table: "Discipline");

            migrationBuilder.DropColumn(
                name: "countHoursGZ",
                table: "Discipline");

            migrationBuilder.DropColumn(
                name: "countHoursLR",
                table: "Discipline");

            migrationBuilder.DropColumn(
                name: "countHoursLeck",
                table: "Discipline");

            migrationBuilder.DropColumn(
                name: "countHoursMZ",
                table: "Discipline");

            migrationBuilder.DropColumn(
                name: "countHoursPZ",
                table: "Discipline");

            migrationBuilder.DropColumn(
                name: "countHoursSEM",
                table: "Discipline");

            migrationBuilder.DropColumn(
                name: "countHoursSWZ",
                table: "Discipline");
        }
    }
}
