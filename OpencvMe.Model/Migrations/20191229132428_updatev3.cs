using Microsoft.EntityFrameworkCore.Migrations;

namespace OpencvMe.Model.Migrations
{
    public partial class updatev3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IsMale",
                table: "User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IsMale",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
