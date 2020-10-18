using Microsoft.EntityFrameworkCore.Migrations;

namespace OpencvMe.WebApi.Migrations
{
    public partial class update_db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Cv",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "Cv",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Youtube",
                table: "Cv",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Cv");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "Cv");

            migrationBuilder.DropColumn(
                name: "Youtube",
                table: "Cv");
        }
    }
}
