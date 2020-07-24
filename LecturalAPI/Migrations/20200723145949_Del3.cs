using Microsoft.EntityFrameworkCore.Migrations;

namespace LecturalAPI.Migrations
{
    public partial class Del3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "numberOfGroup",
                table: "Timetable",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "fullName",
                table: "Discipline",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fullName",
                table: "Discipline");

            migrationBuilder.AlterColumn<string>(
                name: "numberOfGroup",
                table: "Timetable",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
