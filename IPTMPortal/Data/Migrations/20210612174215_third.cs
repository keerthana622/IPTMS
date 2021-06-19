using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IPTMPortal.Data.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "TreatmentPlan",
                columns: table => new
                {
                    PlanId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(nullable: false),
                    AilmentName = table.Column<string>(nullable: true),
                    PackageName = table.Column<string>(nullable: true),
                    TestDetails = table.Column<string>(nullable: true),
                    Cost = table.Column<double>(nullable: false),
                    SpecialistName = table.Column<string>(nullable: true),
                    TreatmentCommencementDate = table.Column<DateTime>(nullable: false),
                    TreatmentEndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentPlan", x => x.PlanId);
                    table.ForeignKey(
                        name: "FK_TreatmentPlan_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentPlan_PatientId",
                table: "TreatmentPlan",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TreatmentPlan");

            migrationBuilder.DropTable(
                name: "Patient");
        }
    }
}
