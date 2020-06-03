using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LecturalAPI.Migrations
{
    public partial class XZ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idProfession",
                table: "Group");

            migrationBuilder.DropColumn(
                name: "idSpecialization",
                table: "Group");

            migrationBuilder.AddColumn<Guid>(
                name: "ProfessionDBid",
                table: "Group",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SpecializationDBid",
                table: "Group",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Group_ProfessionDBid",
                table: "Group",
                column: "ProfessionDBid");

            migrationBuilder.CreateIndex(
                name: "IX_Group_SpecializationDBid",
                table: "Group",
                column: "SpecializationDBid");

            migrationBuilder.AddForeignKey(
                name: "FK_Group_Profession_ProfessionDBid",
                table: "Group",
                column: "ProfessionDBid",
                principalTable: "Profession",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Group_Specialization_SpecializationDBid",
                table: "Group",
                column: "SpecializationDBid",
                principalTable: "Specialization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Group_Profession_ProfessionDBid",
                table: "Group");

            migrationBuilder.DropForeignKey(
                name: "FK_Group_Specialization_SpecializationDBid",
                table: "Group");

            migrationBuilder.DropIndex(
                name: "IX_Group_ProfessionDBid",
                table: "Group");

            migrationBuilder.DropIndex(
                name: "IX_Group_SpecializationDBid",
                table: "Group");

            migrationBuilder.DropColumn(
                name: "ProfessionDBid",
                table: "Group");

            migrationBuilder.DropColumn(
                name: "SpecializationDBid",
                table: "Group");

            migrationBuilder.AddColumn<Guid>(
                name: "idProfession",
                table: "Group",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "idSpecialization",
                table: "Group",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
