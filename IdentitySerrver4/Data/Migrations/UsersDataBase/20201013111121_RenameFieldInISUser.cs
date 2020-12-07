using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentitySerrver4.Data.Migrations.UsersDataBase
{
    public partial class RenameFieldInISUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "family_name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "middle_name",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "AspNetUsers",
                newName: "Gender");

            migrationBuilder.AddColumn<string>(
                name: "FamilyName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FamilyName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "AspNetUsers",
                newName: "gender");

            migrationBuilder.AddColumn<string>(
                name: "family_name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "middle_name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
