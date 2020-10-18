using Microsoft.EntityFrameworkCore.Migrations;

namespace OpencvMe.WebApi.Migrations
{
    public partial class LicenseDegree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "licenseDegree",
                table: "UserSchool",
                newName: "LicenseDegree");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LicenseDegree",
                table: "UserSchool",
                newName: "licenseDegree");
        }
    }
}
