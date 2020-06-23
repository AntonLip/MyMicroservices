using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LecturalAPI.Migrations
{
    public partial class NewDataLecturalAndSomeClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "Lectural");

            migrationBuilder.DropColumn(
                name: "academicDegree",
                table: "Lectural");

            migrationBuilder.DropColumn(
                name: "academicTitle",
                table: "Lectural");

            migrationBuilder.DropColumn(
                name: "militaryRank",
                table: "Lectural");

            migrationBuilder.AddColumn<Guid>(
                name: "AcademicDegreeid",
                table: "Lectural",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AcademicTitleid",
                table: "Lectural",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MilitaryRankid",
                table: "Lectural",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Positionid",
                table: "Lectural",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "serialAndNumderCivilyDocs",
                table: "Lectural",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "serialAndNumderMilitaryDocs",
                table: "Lectural",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AcademicDegree",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicDegree", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AcademicTitle",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicTitle", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MilitaryRank",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilitaryRank", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    koeff = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lectural_AcademicDegreeid",
                table: "Lectural",
                column: "AcademicDegreeid");

            migrationBuilder.CreateIndex(
                name: "IX_Lectural_AcademicTitleid",
                table: "Lectural",
                column: "AcademicTitleid");

            migrationBuilder.CreateIndex(
                name: "IX_Lectural_MilitaryRankid",
                table: "Lectural",
                column: "MilitaryRankid");

            migrationBuilder.CreateIndex(
                name: "IX_Lectural_Positionid",
                table: "Lectural",
                column: "Positionid");

            migrationBuilder.AddForeignKey(
                name: "FK_Lectural_AcademicDegree_AcademicDegreeid",
                table: "Lectural",
                column: "AcademicDegreeid",
                principalTable: "AcademicDegree",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lectural_AcademicTitle_AcademicTitleid",
                table: "Lectural",
                column: "AcademicTitleid",
                principalTable: "AcademicTitle",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lectural_MilitaryRank_MilitaryRankid",
                table: "Lectural",
                column: "MilitaryRankid",
                principalTable: "MilitaryRank",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lectural_Position_Positionid",
                table: "Lectural",
                column: "Positionid",
                principalTable: "Position",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lectural_AcademicDegree_AcademicDegreeid",
                table: "Lectural");

            migrationBuilder.DropForeignKey(
                name: "FK_Lectural_AcademicTitle_AcademicTitleid",
                table: "Lectural");

            migrationBuilder.DropForeignKey(
                name: "FK_Lectural_MilitaryRank_MilitaryRankid",
                table: "Lectural");

            migrationBuilder.DropForeignKey(
                name: "FK_Lectural_Position_Positionid",
                table: "Lectural");

            migrationBuilder.DropTable(
                name: "AcademicDegree");

            migrationBuilder.DropTable(
                name: "AcademicTitle");

            migrationBuilder.DropTable(
                name: "MilitaryRank");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropIndex(
                name: "IX_Lectural_AcademicDegreeid",
                table: "Lectural");

            migrationBuilder.DropIndex(
                name: "IX_Lectural_AcademicTitleid",
                table: "Lectural");

            migrationBuilder.DropIndex(
                name: "IX_Lectural_MilitaryRankid",
                table: "Lectural");

            migrationBuilder.DropIndex(
                name: "IX_Lectural_Positionid",
                table: "Lectural");

            migrationBuilder.DropColumn(
                name: "AcademicDegreeid",
                table: "Lectural");

            migrationBuilder.DropColumn(
                name: "AcademicTitleid",
                table: "Lectural");

            migrationBuilder.DropColumn(
                name: "MilitaryRankid",
                table: "Lectural");

            migrationBuilder.DropColumn(
                name: "Positionid",
                table: "Lectural");

            migrationBuilder.DropColumn(
                name: "serialAndNumderCivilyDocs",
                table: "Lectural");

            migrationBuilder.DropColumn(
                name: "serialAndNumderMilitaryDocs",
                table: "Lectural");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Lectural",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "academicDegree",
                table: "Lectural",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "academicTitle",
                table: "Lectural",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "militaryRank",
                table: "Lectural",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
