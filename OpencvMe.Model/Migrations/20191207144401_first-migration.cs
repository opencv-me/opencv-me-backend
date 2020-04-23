using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OpencvMe.Model.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: false),
                    Language = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Cv",
                columns: table => new
                {
                    CvId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: false),
                    Language = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    CvUrl = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    SurName = table.Column<string>(nullable: true),
                    AboutDescription = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    BirthDay = table.Column<DateTime>(nullable: false),
                    Facebook = table.Column<string>(nullable: true),
                    Linkedin = table.Column<string>(nullable: true),
                    Twitter = table.Column<string>(nullable: true),
                    Instagram = table.Column<string>(nullable: true),
                    Medium = table.Column<string>(nullable: true),
                    IsPublic = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cv", x => x.CvId);
                });

            migrationBuilder.CreateTable(
                name: "School",
                columns: table => new
                {
                    SchoolId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: false),
                    Language = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Level = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School", x => x.SchoolId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: false),
                    Language = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Cv");

            migrationBuilder.DropTable(
                name: "School");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
