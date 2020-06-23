using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LecturalAPI.Migrations
{
    public partial class AddDisciplineToLectural : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Lecturalid",
                table: "Discipline",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Discipline_Lecturalid",
                table: "Discipline",
                column: "Lecturalid");

            migrationBuilder.AddForeignKey(
                name: "FK_Discipline_Lectural_Lecturalid",
                table: "Discipline",
                column: "Lecturalid",
                principalTable: "Lectural",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discipline_Lectural_Lecturalid",
                table: "Discipline");

            migrationBuilder.DropIndex(
                name: "IX_Discipline_Lecturalid",
                table: "Discipline");

            migrationBuilder.DropColumn(
                name: "Lecturalid",
                table: "Discipline");
        }
    }
}
