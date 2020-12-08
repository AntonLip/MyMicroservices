using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LecturalAPI.Migrations
{
    public partial class AddUnits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Unitsid",
                table: "Lectural",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Unitsid",
                table: "Cadet",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    importance = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lectural_Unitsid",
                table: "Lectural",
                column: "Unitsid");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Lectural_Units_Unitsid",
                table: "Lectural",
                column: "Unitsid",
                principalTable: "Units",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cadet_Units_Unitsid",
                table: "Cadet");

            migrationBuilder.DropForeignKey(
                name: "FK_Lectural_Units_Unitsid",
                table: "Lectural");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Lectural_Unitsid",
                table: "Lectural");

            migrationBuilder.DropIndex(
                name: "IX_Cadet_Unitsid",
                table: "Cadet");

            migrationBuilder.DropColumn(
                name: "Unitsid",
                table: "Lectural");

            migrationBuilder.DropColumn(
                name: "Unitsid",
                table: "Cadet");
        }
    }
}
