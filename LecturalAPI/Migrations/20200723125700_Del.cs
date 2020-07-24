using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LecturalAPI.Migrations
{
    public partial class Del : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discipline_Group_GroupDBid",
                table: "Discipline");

            migrationBuilder.DropIndex(
                name: "IX_Discipline_GroupDBid",
                table: "Discipline");

            migrationBuilder.DropColumn(
                name: "GroupDBid",
                table: "Discipline");

            migrationBuilder.AddColumn<string>(
                name: "infoForEngeneers",
                table: "Timetable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "infoForLectural",
                table: "Timetable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "infoForcadets",
                table: "Timetable",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SpecializationDBid",
                table: "Discipline",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Discipline_SpecializationDBid",
                table: "Discipline",
                column: "SpecializationDBid");

            migrationBuilder.AddForeignKey(
                name: "FK_Discipline_Specialization_SpecializationDBid",
                table: "Discipline",
                column: "SpecializationDBid",
                principalTable: "Specialization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discipline_Specialization_SpecializationDBid",
                table: "Discipline");

            migrationBuilder.DropIndex(
                name: "IX_Discipline_SpecializationDBid",
                table: "Discipline");

            migrationBuilder.DropColumn(
                name: "infoForEngeneers",
                table: "Timetable");

            migrationBuilder.DropColumn(
                name: "infoForLectural",
                table: "Timetable");

            migrationBuilder.DropColumn(
                name: "infoForcadets",
                table: "Timetable");

            migrationBuilder.DropColumn(
                name: "SpecializationDBid",
                table: "Discipline");

            migrationBuilder.AddColumn<Guid>(
                name: "GroupDBid",
                table: "Discipline",
                type: "uniqueidentifier",
                nullable: true);

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
        }
    }
}
