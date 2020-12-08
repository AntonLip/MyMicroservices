using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LecturalAPI.Migrations
{
    public partial class ChangeUnits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cadet_Units_Unitsid",
                table: "Cadet");

            migrationBuilder.DropIndex(
                name: "IX_Cadet_Unitsid",
                table: "Cadet");

            migrationBuilder.DropColumn(
                name: "Unitsid",
                table: "Cadet");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Unitsid",
                table: "Cadet",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cadet_Unitsid",
                table: "Cadet",
                column: "Unitsid");

            migrationBuilder.AddForeignKey(
                name: "FK_Cadet_Units_Unitsid",
                table: "Cadet",
                column: "Unitsid",
                principalTable: "Units",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
