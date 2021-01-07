using Microsoft.EntityFrameworkCore.Migrations;

namespace LecturalAPI.Migrations
{
    public partial class DelSomeFieldInGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountCadets",
                table: "Group");

            migrationBuilder.AddColumn<bool>(
                name: "isLectural",
                table: "Lectural",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "telephoneNumber",
                table: "Lectural",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isLectural",
                table: "Lectural");

            migrationBuilder.DropColumn(
                name: "telephoneNumber",
                table: "Lectural");

            migrationBuilder.AddColumn<int>(
                name: "CountCadets",
                table: "Group",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
