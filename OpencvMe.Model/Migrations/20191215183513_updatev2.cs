using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OpencvMe.Model.Migrations
{
    public partial class updatev2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "UserSchool",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "UserSchool",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "UserSchool");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "UserSchool");
        }
    }
}
