using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LecturalAPI.Migrations
{
    public partial class AddFieldToLesson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pathToMaterials",
                table: "Lesson");

            migrationBuilder.AddColumn<byte[]>(
                name: "AdditionalInfoDoc",
                table: "LessonType",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "MethodicDoc",
                table: "LessonType",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Presentation",
                table: "LessonType",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "AdditionalMaterial",
                table: "Lesson",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "MethodicMaterials",
                table: "Lesson",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Presentation",
                table: "Lesson",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalInfoDoc",
                table: "LessonType");

            migrationBuilder.DropColumn(
                name: "MethodicDoc",
                table: "LessonType");

            migrationBuilder.DropColumn(
                name: "Presentation",
                table: "LessonType");

            migrationBuilder.DropColumn(
                name: "AdditionalMaterial",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "MethodicMaterials",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "Presentation",
                table: "Lesson");

            migrationBuilder.AddColumn<string>(
                name: "pathToMaterials",
                table: "Lesson",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
