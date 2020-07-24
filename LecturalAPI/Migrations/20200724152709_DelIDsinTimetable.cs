using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LecturalAPI.Migrations
{
    public partial class DelIDsinTimetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Timetable_Discipline_DisciplineDBid",
                table: "Timetable");

            migrationBuilder.DropForeignKey(
                name: "FK_Timetable_Group_GroupDBid",
                table: "Timetable");

            migrationBuilder.DropForeignKey(
                name: "FK_Timetable_Lesson_LessonDBid",
                table: "Timetable");

            migrationBuilder.AlterColumn<Guid>(
                name: "LessonDBid",
                table: "Timetable",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "GroupDBid",
                table: "Timetable",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "DisciplineDBid",
                table: "Timetable",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Timetable_Discipline_DisciplineDBid",
                table: "Timetable",
                column: "DisciplineDBid",
                principalTable: "Discipline",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Timetable_Group_GroupDBid",
                table: "Timetable",
                column: "GroupDBid",
                principalTable: "Group",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Timetable_Lesson_LessonDBid",
                table: "Timetable",
                column: "LessonDBid",
                principalTable: "Lesson",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Timetable_Discipline_DisciplineDBid",
                table: "Timetable");

            migrationBuilder.DropForeignKey(
                name: "FK_Timetable_Group_GroupDBid",
                table: "Timetable");

            migrationBuilder.DropForeignKey(
                name: "FK_Timetable_Lesson_LessonDBid",
                table: "Timetable");

            migrationBuilder.AlterColumn<Guid>(
                name: "LessonDBid",
                table: "Timetable",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "GroupDBid",
                table: "Timetable",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DisciplineDBid",
                table: "Timetable",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Timetable_Discipline_DisciplineDBid",
                table: "Timetable",
                column: "DisciplineDBid",
                principalTable: "Discipline",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Timetable_Group_GroupDBid",
                table: "Timetable",
                column: "GroupDBid",
                principalTable: "Group",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Timetable_Lesson_LessonDBid",
                table: "Timetable",
                column: "LessonDBid",
                principalTable: "Lesson",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
