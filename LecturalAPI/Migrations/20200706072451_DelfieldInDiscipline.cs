using Microsoft.EntityFrameworkCore.Migrations;

namespace LecturalAPI.Migrations
{
    public partial class DelfieldInDiscipline : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "countCourseWorkours",
                table: "Discipline");

            migrationBuilder.DropColumn(
                name: "countCourseWorksHours",
                table: "Discipline");

            migrationBuilder.DropColumn(
                name: "countGroupsHours",
                table: "Discipline");

            migrationBuilder.DropColumn(
                name: "countLecturalThreads",
                table: "Discipline");

            migrationBuilder.DropColumn(
                name: "countLectureHours",
                table: "Discipline");

            migrationBuilder.DropColumn(
                name: "countMetodicalHours",
                table: "Discipline");

            migrationBuilder.DropColumn(
                name: "countPracticalHours",
                table: "Discipline");

            migrationBuilder.DropColumn(
                name: "countPracticalThreads",
                table: "Discipline");

            migrationBuilder.DropColumn(
                name: "countSelfWorkHours",
                table: "Discipline");

            migrationBuilder.DropColumn(
                name: "countSeminarsHours",
                table: "Discipline");

            migrationBuilder.DropColumn(
                name: "countTacticalHours",
                table: "Discipline");

            migrationBuilder.DropColumn(
                name: "countTestHours",
                table: "Discipline");

            migrationBuilder.DropColumn(
                name: "countTestWithScoreHours",
                table: "Discipline");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "countCourseWorkours",
                table: "Discipline",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "countCourseWorksHours",
                table: "Discipline",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "countGroupsHours",
                table: "Discipline",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "countLecturalThreads",
                table: "Discipline",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "countLectureHours",
                table: "Discipline",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "countMetodicalHours",
                table: "Discipline",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "countPracticalHours",
                table: "Discipline",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "countPracticalThreads",
                table: "Discipline",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "countSelfWorkHours",
                table: "Discipline",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "countSeminarsHours",
                table: "Discipline",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "countTacticalHours",
                table: "Discipline",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "countTestHours",
                table: "Discipline",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "countTestWithScoreHours",
                table: "Discipline",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
