using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LecturalAPI.Migrations
{
    public partial class withTimetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dateofLesson",
                table: "Lesson");

            migrationBuilder.AddColumn<int>(
                name: "currentNumberOflessonsType",
                table: "Lesson",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Timetable",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    numberOfWeek = table.Column<int>(nullable: false),
                    numberOfLesson = table.Column<int>(nullable: false),
                    dateOfLesson = table.Column<DateTime>(nullable: false),
                    LessonDBid = table.Column<Guid>(nullable: false),
                    GroupDBid = table.Column<Guid>(nullable: false),
                    DisciplineDBid = table.Column<Guid>(nullable: false),
                    numberOfAud = table.Column<int>(nullable: false),
                    firstLecturalid = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timetable", x => x.id);
                    table.ForeignKey(
                        name: "FK_Timetable_Discipline_DisciplineDBid",
                        column: x => x.DisciplineDBid,
                        principalTable: "Discipline",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Timetable_Group_GroupDBid",
                        column: x => x.GroupDBid,
                        principalTable: "Group",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Timetable_Lesson_LessonDBid",
                        column: x => x.LessonDBid,
                        principalTable: "Lesson",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Timetable_Lectural_firstLecturalid",
                        column: x => x.firstLecturalid,
                        principalTable: "Lectural",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Timetable_DisciplineDBid",
                table: "Timetable",
                column: "DisciplineDBid");

            migrationBuilder.CreateIndex(
                name: "IX_Timetable_GroupDBid",
                table: "Timetable",
                column: "GroupDBid");

            migrationBuilder.CreateIndex(
                name: "IX_Timetable_LessonDBid",
                table: "Timetable",
                column: "LessonDBid");

            migrationBuilder.CreateIndex(
                name: "IX_Timetable_firstLecturalid",
                table: "Timetable",
                column: "firstLecturalid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Timetable");

            migrationBuilder.DropColumn(
                name: "currentNumberOflessonsType",
                table: "Lesson");

            migrationBuilder.AddColumn<DateTime>(
                name: "dateofLesson",
                table: "Lesson",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
