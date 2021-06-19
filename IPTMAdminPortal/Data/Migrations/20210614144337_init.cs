using Microsoft.EntityFrameworkCore.Migrations;

namespace IPTMAdminPortal.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Insurer",
                columns: table => new
                {
                    InsurerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsurerName = table.Column<string>(nullable: true),
                    InsurerPackageName = table.Column<string>(nullable: true),
                    AmountLimit = table.Column<long>(nullable: false),
                    DisbursementDuration = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurer", x => x.InsurerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Insurer");
        }
    }
}
