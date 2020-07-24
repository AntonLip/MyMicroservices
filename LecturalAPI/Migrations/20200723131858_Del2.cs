using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LecturalAPI.Migrations
{
    public partial class Del2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Timetable_Lectural_firstLecturalid",
                table: "Timetable");

            migrationBuilder.DropIndex(
                name: "IX_Timetable_firstLecturalid",
                table: "Timetable");

            migrationBuilder.DropColumn(
                name: "dateOfLesson",
                table: "Timetable");

            migrationBuilder.DropColumn(
                name: "firstLecturalid",
                table: "Timetable");

            migrationBuilder.DropColumn(
                name: "numberOfAud",
                table: "Timetable");

            migrationBuilder.DropColumn(
                name: "InfoForLectural",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "auditoreNumber",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "infoForCadets",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "infoForEngeneer",
                table: "Lesson");

            migrationBuilder.AddColumn<string>(
                name: "Lectural",
                table: "Timetable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "auditore",
                table: "Timetable",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                table: "Timetable",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "dayOfWeek",
                table: "Timetable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nameOfDiscipline",
                table: "Timetable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "numberOfGroup",
                table: "Timetable",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "numbewrOfDayInWeek",
                table: "Timetable",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "refLecturalid",
                table: "Timetable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "typeOfLesson",
                table: "Timetable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pathToMaterials",
                table: "Lesson",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Timetable_refLecturalid",
                table: "Timetable",
                column: "refLecturalid");

            migrationBuilder.AddForeignKey(
                name: "FK_Timetable_Lectural_refLecturalid",
                table: "Timetable",
                column: "refLecturalid",
                principalTable: "Lectural",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Timetable_Lectural_refLecturalid",
                table: "Timetable");

            migrationBuilder.DropIndex(
                name: "IX_Timetable_refLecturalid",
                table: "Timetable");

            migrationBuilder.DropColumn(
                name: "Lectural",
                table: "Timetable");

            migrationBuilder.DropColumn(
                name: "auditore",
                table: "Timetable");

            migrationBuilder.DropColumn(
                name: "date",
                table: "Timetable");

            migrationBuilder.DropColumn(
                name: "dayOfWeek",
                table: "Timetable");

            migrationBuilder.DropColumn(
                name: "nameOfDiscipline",
                table: "Timetable");

            migrationBuilder.DropColumn(
                name: "numberOfGroup",
                table: "Timetable");

            migrationBuilder.DropColumn(
                name: "numbewrOfDayInWeek",
                table: "Timetable");

            migrationBuilder.DropColumn(
                name: "refLecturalid",
                table: "Timetable");

            migrationBuilder.DropColumn(
                name: "typeOfLesson",
                table: "Timetable");

            migrationBuilder.DropColumn(
                name: "pathToMaterials",
                table: "Lesson");

            migrationBuilder.AddColumn<DateTime>(
                name: "dateOfLesson",
                table: "Timetable",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "firstLecturalid",
                table: "Timetable",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "numberOfAud",
                table: "Timetable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "InfoForLectural",
                table: "Lesson",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "auditoreNumber",
                table: "Lesson",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "infoForCadets",
                table: "Lesson",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "infoForEngeneer",
                table: "Lesson",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Timetable_firstLecturalid",
                table: "Timetable",
                column: "firstLecturalid");

            migrationBuilder.AddForeignKey(
                name: "FK_Timetable_Lectural_firstLecturalid",
                table: "Timetable",
                column: "firstLecturalid",
                principalTable: "Lectural",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
