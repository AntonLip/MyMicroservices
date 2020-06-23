using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LecturalAPI.Migrations
{
    public partial class AddGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Group_Profession_ProfessionDBid",
                table: "Group");

            migrationBuilder.DropForeignKey(
                name: "FK_Group_Specialization_SpecializationDBid",
                table: "Group");

            migrationBuilder.DropColumn(
                name: "idGrup",
                table: "Cadet");

            migrationBuilder.AlterColumn<Guid>(
                name: "SpecializationDBid",
                table: "Group",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ProfessionDBid",
                table: "Group",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GroupDBid",
                table: "Cadet",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Cadet_GroupDBid",
                table: "Cadet",
                column: "GroupDBid");

            migrationBuilder.AddForeignKey(
                name: "FK_Cadet_Group_GroupDBid",
                table: "Cadet",
                column: "GroupDBid",
                principalTable: "Group",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Group_Profession_ProfessionDBid",
                table: "Group",
                column: "ProfessionDBid",
                principalTable: "Profession",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Group_Specialization_SpecializationDBid",
                table: "Group",
                column: "SpecializationDBid",
                principalTable: "Specialization",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cadet_Group_GroupDBid",
                table: "Cadet");

            migrationBuilder.DropForeignKey(
                name: "FK_Group_Profession_ProfessionDBid",
                table: "Group");

            migrationBuilder.DropForeignKey(
                name: "FK_Group_Specialization_SpecializationDBid",
                table: "Group");

            migrationBuilder.DropIndex(
                name: "IX_Cadet_GroupDBid",
                table: "Cadet");

            migrationBuilder.DropColumn(
                name: "GroupDBid",
                table: "Cadet");

            migrationBuilder.AlterColumn<Guid>(
                name: "SpecializationDBid",
                table: "Group",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "ProfessionDBid",
                table: "Group",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "idGrup",
                table: "Cadet",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Group_Profession_ProfessionDBid",
                table: "Group",
                column: "ProfessionDBid",
                principalTable: "Profession",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Group_Specialization_SpecializationDBid",
                table: "Group",
                column: "SpecializationDBid",
                principalTable: "Specialization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
