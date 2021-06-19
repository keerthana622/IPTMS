using Microsoft.EntityFrameworkCore.Migrations;

namespace InsuranceClaimMicroservice.Migrations
{
    public partial class insurance_init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Insurers",
                columns: table => new
                {
                    InsurerId = table.Column<int>(type: "int", nullable: false),
                    InsurerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsurerPackageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmountLimit = table.Column<long>(type: "bigint", nullable: false),
                    DisbursementDuration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurers", x => x.InsurerId);
                });

            migrationBuilder.CreateTable(
                name: "Claims",
                columns: table => new
                {
                    ClaimId = table.Column<int>(type: "int", nullable: false),
                    PlanId = table.Column<int>(type: "int", nullable: false),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AilmentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsurerId = table.Column<int>(type: "int", nullable: false),
                    InsurerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaybleBalance = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claims", x => x.ClaimId);
                    table.ForeignKey(
                        name: "FK_Claims_Insurers_InsurerId",
                        column: x => x.InsurerId,
                        principalTable: "Insurers",
                        principalColumn: "InsurerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Claims_InsurerId",
                table: "Claims",
                column: "InsurerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Claims");

            migrationBuilder.DropTable(
                name: "Insurers");
        }
    }
}
