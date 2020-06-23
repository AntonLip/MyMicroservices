using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LecturalAPI.Migrations
{
    public partial class ChangeCadetsLessonLectural : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Info",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "idDiciplines",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "idLectural",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "idLessonType",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "numberOfDiciplines",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "idProfession",
                table: "Discipline");

            migrationBuilder.DropColumn(
                name: "idSpecialization",
                table: "Discipline");

            migrationBuilder.AddColumn<Guid>(
                name: "Disciplineid",
                table: "Lesson",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InfoForLectural",
                table: "Lesson",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Lecturalid",
                table: "Lesson",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LessonTypeDBid",
                table: "Lesson",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "auditoreNumber",
                table: "Lesson",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "infoForCadets",
                table: "Lesson",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "infoForEngeneer",
                table: "Lesson",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GroupDBid",
                table: "Discipline",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_Disciplineid",
                table: "Lesson",
                column: "Disciplineid");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_Lecturalid",
                table: "Lesson",
                column: "Lecturalid");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_LessonTypeDBid",
                table: "Lesson",
                column: "LessonTypeDBid");

            migrationBuilder.CreateIndex(
                name: "IX_Discipline_GroupDBid",
                table: "Discipline",
                column: "GroupDBid");

            migrationBuilder.AddForeignKey(
                name: "FK_Discipline_Group_GroupDBid",
                table: "Discipline",
                column: "GroupDBid",
                principalTable: "Group",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_Discipline_Disciplineid",
                table: "Lesson",
                column: "Disciplineid",
                principalTable: "Discipline",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_Lectural_Lecturalid",
                table: "Lesson",
                column: "Lecturalid",
                principalTable: "Lectural",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_LessonType_LessonTypeDBid",
                table: "Lesson",
                column: "LessonTypeDBid",
                principalTable: "LessonType",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discipline_Group_GroupDBid",
                table: "Discipline");

            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_Discipline_Disciplineid",
                table: "Lesson");

            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_Lectural_Lecturalid",
                table: "Lesson");

            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_LessonType_LessonTypeDBid",
                table: "Lesson");

            migrationBuilder.DropIndex(
                name: "IX_Lesson_Disciplineid",
                table: "Lesson");

            migrationBuilder.DropIndex(
                name: "IX_Lesson_Lecturalid",
                table: "Lesson");

            migrationBuilder.DropIndex(
                name: "IX_Lesson_LessonTypeDBid",
                table: "Lesson");

            migrationBuilder.DropIndex(
                name: "IX_Discipline_GroupDBid",
                table: "Discipline");

            migrationBuilder.DropColumn(
                name: "Disciplineid",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "InfoForLectural",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "Lecturalid",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "LessonTypeDBid",
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

            migrationBuilder.DropColumn(
                name: "GroupDBid",
                table: "Discipline");

            migrationBuilder.AddColumn<string>(
                name: "Info",
                table: "Lesson",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "idDiciplines",
                table: "Lesson",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "idLectural",
                table: "Lesson",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "idLessonType",
                table: "Lesson",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "numberOfDiciplines",
                table: "Lesson",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "idProfession",
                table: "Discipline",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "idSpecialization",
                table: "Discipline",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
