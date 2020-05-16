using Microsoft.EntityFrameworkCore.Migrations;

namespace OpencvMe.WebApi.Migrations
{
    public partial class db_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "licenseDegree",
                table: "UserSchool",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "licenseDegree",
                table: "UserSchool");
        }
    }
}
