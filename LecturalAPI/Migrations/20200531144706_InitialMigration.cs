using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LecturalAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lectural",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    lastName = table.Column<string>(nullable: true),
                    firstName = table.Column<string>(nullable: true),
                    middleName = table.Column<string>(nullable: true),
                    birthDay = table.Column<DateTime>(nullable: false),
                    pathPhotoSmall = table.Column<string>(nullable: true),
                    pathPhotoBig = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    dateOfStartService = table.Column<DateTime>(nullable: false),
                    isMarried = table.Column<bool>(nullable: false),
                    militaryRank = table.Column<string>(nullable: true),
                    academicTitle = table.Column<string>(nullable: true),
                    academicDegree = table.Column<string>(nullable: true),
                    countOfChildren = table.Column<int>(nullable: false),
                    info = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectural", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lectural");
        }
    }
}
