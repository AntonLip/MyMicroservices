using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LecturalAPI.Migrations
{
    public partial class AddSomeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cadet",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    idGrup = table.Column<Guid>(nullable: false),
                    lastName = table.Column<string>(nullable: true),
                    firstName = table.Column<string>(nullable: true),
                    middleName = table.Column<string>(nullable: true),
                    birthDay = table.Column<DateTime>(nullable: false),
                    pathPhotoSmall = table.Column<string>(nullable: true),
                    pathPhotoBig = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    dateOfStartService = table.Column<DateTime>(nullable: false),
                    isMarried = table.Column<bool>(nullable: false),
                    militaryRank = table.Column<string>(nullable: true),
                    info = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cadet", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Discipline",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    countHours = table.Column<int>(nullable: false),
                    idLectural = table.Column<Guid>(nullable: false),
                    countLectureHours = table.Column<int>(nullable: false),
                    countLecturalThreads = table.Column<int>(nullable: false),
                    countPracticalThreads = table.Column<int>(nullable: false),
                    countPracticalHours = table.Column<int>(nullable: false),
                    countMetodicalHours = table.Column<int>(nullable: false),
                    countSeminarsHours = table.Column<int>(nullable: false),
                    countGroupsHours = table.Column<int>(nullable: false),
                    countTacticalHours = table.Column<int>(nullable: false),
                    countCourseWorkours = table.Column<int>(nullable: false),
                    countCourseWorksHours = table.Column<int>(nullable: false),
                    countSelfWorkHours = table.Column<int>(nullable: false),
                    countTestHours = table.Column<int>(nullable: false),
                    countTestWithScoreHours = table.Column<int>(nullable: false),
                    isExam = table.Column<bool>(nullable: false),
                    idProfession = table.Column<Guid>(nullable: false),
                    idSpecialization = table.Column<Guid>(nullable: false),
                    dateOfPlan = table.Column<DateTime>(nullable: false),
                    countNorm = table.Column<int>(nullable: false),
                    Semester = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discipline", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    idProfession = table.Column<Guid>(nullable: false),
                    idSpecialization = table.Column<Guid>(nullable: false),
                    numberOfGroup = table.Column<int>(nullable: false),
                    CountCadets = table.Column<int>(nullable: false),
                    info = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Lesson",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    sectionName = table.Column<string>(nullable: true),
                    themeName = table.Column<string>(nullable: true),
                    idLectural = table.Column<Guid>(nullable: false),
                    idDiciplines = table.Column<Guid>(nullable: false),
                    idLessonType = table.Column<Guid>(nullable: false),
                    numberOfDiciplines = table.Column<int>(nullable: false),
                    countHours = table.Column<int>(nullable: false),
                    Info = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lesson", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "LessonType",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    nameOfType = table.Column<string>(nullable: true),
                    info = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonType", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Profession",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    proffesionCode = table.Column<string>(nullable: true),
                    nameOfProffession = table.Column<string>(nullable: true),
                    info = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profession", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Specialization",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    SpecializationCode = table.Column<string>(nullable: true),
                    nameOfSpecialization = table.Column<string>(nullable: true),
                    info = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialization", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cadet");

            migrationBuilder.DropTable(
                name: "Discipline");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "Lesson");

            migrationBuilder.DropTable(
                name: "LessonType");

            migrationBuilder.DropTable(
                name: "Profession");

            migrationBuilder.DropTable(
                name: "Specialization");
        }
    }
}
