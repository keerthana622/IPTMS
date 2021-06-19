using Microsoft.EntityFrameworkCore.Migrations;

namespace IPTMPortal.Data.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PatientServicePackageView",
                columns: table => new
                {
                    PackageName = table.Column<string>(nullable: false),
                    Ailment = table.Column<string>(nullable: true),
                    TestDetails = table.Column<string>(nullable: true),
                    Cost = table.Column<double>(nullable: false),
                    Duration = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientServicePackageView", x => x.PackageName);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientServicePackageView");
        }
    }
}
