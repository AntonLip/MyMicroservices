using Microsoft.EntityFrameworkCore.Migrations;

namespace LecturalAPI.Migrations
{
    public partial class RenameFieldInLessonType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nameOfType",
                table: "LessonType");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "LessonType",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "LessonType");

            migrationBuilder.AddColumn<string>(
                name: "nameOfType",
                table: "LessonType",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
