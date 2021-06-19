using Microsoft.EntityFrameworkCore.Migrations;

namespace IPTMAdminPortal.Data.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Claim",
                columns: table => new
                {
                    ClaimId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanId = table.Column<int>(nullable: false),
                    PatientName = table.Column<string>(nullable: true),
                    AilmentName = table.Column<string>(nullable: true),
                    PackageName = table.Column<string>(nullable: true),
                    InsurerId = table.Column<int>(nullable: false),
                    InsurerName = table.Column<string>(nullable: true),
                    PaybleBalance = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claim", x => x.ClaimId);
                    table.ForeignKey(
                        name: "FK_Claim_Insurer_InsurerId",
                        column: x => x.InsurerId,
                        principalTable: "Insurer",
                        principalColumn: "InsurerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Ailment = table.Column<string>(nullable: true),
                    PackageName = table.Column<string>(nullable: true),
                    CommencementDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Claim_InsurerId",
                table: "Claim",
                column: "InsurerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Claim");

            migrationBuilder.DropTable(
                name: "Patient");
        }
    }
}
