using Microsoft.EntityFrameworkCore.Migrations;

namespace IPTMPortal.Data.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpecialistView",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Expertise = table.Column<string>(nullable: true),
                    YearsOfExp = table.Column<int>(nullable: false),
                    Contact = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialistView", x => x.Name);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpecialistView");
        }
    }
}
