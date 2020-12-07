using Microsoft.EntityFrameworkCore.Migrations;

namespace LecturalAPI.Migrations
{
    public partial class NulladleValueInDisc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "countHoursTest",
                table: "Discipline",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "countHoursСontrolWork",
                table: "Discipline",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "countHoursTest",
                table: "Discipline");

            migrationBuilder.DropColumn(
                name: "countHoursСontrolWork",
                table: "Discipline");
        }
    }
}
