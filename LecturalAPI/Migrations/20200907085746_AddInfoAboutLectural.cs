using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LecturalAPI.Migrations
{
    public partial class AddInfoAboutLectural : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Timetable_Lectural_refLecturalid",
                table: "Timetable");

            migrationBuilder.DropIndex(
                name: "IX_Timetable_refLecturalid",
                table: "Timetable");

            migrationBuilder.DropColumn(
                name: "refLecturalid",
                table: "Timetable");

            migrationBuilder.AddColumn<Guid>(
                name: "Lecturalid",
                table: "Timetable",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateFormSec",
                table: "Lectural",
                nullable: true,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "FormSec",
                table: "Lectural",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "dateOfExpiry",
                table: "Lectural",
                nullable: true,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dateOfIssue",
                table: "Lectural",
                nullable: true,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "nameOFVoinkom",
                table: "Lectural",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "whoGetPassport",
                table: "Lectural",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Childrens",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    lastName = table.Column<string>(nullable: true),
                    firstName = table.Column<string>(nullable: true),
                    middleName = table.Column<string>(nullable: true),
                    birthDay = table.Column<DateTime>(nullable: false),
                    pathPhotoSmall = table.Column<string>(nullable: true),
                    pathPhotoBig = table.Column<string>(nullable: true),
                    info = table.Column<string>(nullable: true),
                    Lecturalid = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Childrens", x => x.id);
                    table.ForeignKey(
                        name: "FK_Childrens_Lectural_Lecturalid",
                        column: x => x.Lecturalid,
                        principalTable: "Lectural",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Wifes",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    lastName = table.Column<string>(nullable: true),
                    firstName = table.Column<string>(nullable: true),
                    middleName = table.Column<string>(nullable: true),
                    birthDay = table.Column<DateTime>(nullable: false),
                    pathPhotoSmall = table.Column<string>(nullable: true),
                    pathPhotoBig = table.Column<string>(nullable: true),
                    info = table.Column<string>(nullable: true),
                    Lecturalid = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wifes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Wifes_Lectural_Lecturalid",
                        column: x => x.Lecturalid,
                        principalTable: "Lectural",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Timetable_Lecturalid",
                table: "Timetable",
                column: "Lecturalid");

            migrationBuilder.CreateIndex(
                name: "IX_Childrens_Lecturalid",
                table: "Childrens",
                column: "Lecturalid");

            migrationBuilder.CreateIndex(
                name: "IX_Wifes_Lecturalid",
                table: "Wifes",
                column: "Lecturalid");

            migrationBuilder.AddForeignKey(
                name: "FK_Timetable_Lectural_Lecturalid",
                table: "Timetable",
                column: "Lecturalid",
                principalTable: "Lectural",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Timetable_Lectural_Lecturalid",
                table: "Timetable");

            migrationBuilder.DropTable(
                name: "Childrens");

            migrationBuilder.DropTable(
                name: "Wifes");

            migrationBuilder.DropIndex(
                name: "IX_Timetable_Lecturalid",
                table: "Timetable");

            migrationBuilder.DropColumn(
                name: "Lecturalid",
                table: "Timetable");

            migrationBuilder.DropColumn(
                name: "DateFormSec",
                table: "Lectural");

            migrationBuilder.DropColumn(
                name: "FormSec",
                table: "Lectural");

            migrationBuilder.DropColumn(
                name: "dateOfExpiry",
                table: "Lectural");

            migrationBuilder.DropColumn(
                name: "dateOfIssue",
                table: "Lectural");

            migrationBuilder.DropColumn(
                name: "nameOFVoinkom",
                table: "Lectural");

            migrationBuilder.DropColumn(
                name: "whoGetPassport",
                table: "Lectural");

            migrationBuilder.AddColumn<Guid>(
                name: "refLecturalid",
                table: "Timetable",
                type: "uniqueidentifier",
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
    }
}
