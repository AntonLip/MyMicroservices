using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LecturalAPI.Migrations
{
    public partial class DelSomeFieldInLectural : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Childrens_Lectural_Lecturalid",
                table: "Childrens");

            migrationBuilder.DropForeignKey(
                name: "FK_Wifes_Lectural_Lecturalid",
                table: "Wifes");

            migrationBuilder.DropIndex(
                name: "IX_Wifes_Lecturalid",
                table: "Wifes");

            migrationBuilder.DropIndex(
                name: "IX_Childrens_Lecturalid",
                table: "Childrens");

            migrationBuilder.DropColumn(
                name: "Lecturalid",
                table: "Wifes");

            migrationBuilder.DropColumn(
                name: "countOfChildren",
                table: "Lectural");

            migrationBuilder.DropColumn(
                name: "Lecturalid",
                table: "Childrens");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Lecturalid",
                table: "Wifes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "countOfChildren",
                table: "Lectural",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "Lecturalid",
                table: "Childrens",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wifes_Lecturalid",
                table: "Wifes",
                column: "Lecturalid");

            migrationBuilder.CreateIndex(
                name: "IX_Childrens_Lecturalid",
                table: "Childrens",
                column: "Lecturalid");

            migrationBuilder.AddForeignKey(
                name: "FK_Childrens_Lectural_Lecturalid",
                table: "Childrens",
                column: "Lecturalid",
                principalTable: "Lectural",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wifes_Lectural_Lecturalid",
                table: "Wifes",
                column: "Lecturalid",
                principalTable: "Lectural",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
