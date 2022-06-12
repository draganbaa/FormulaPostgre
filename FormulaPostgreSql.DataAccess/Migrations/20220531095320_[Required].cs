using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FormulaPostgreSql.DataAccess.Migrations
{
    public partial class Required : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QualifyingResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Fastestlapq1 = table.Column<TimeSpan>(type: "interval", nullable: true),
                    Fastestlapq2 = table.Column<TimeSpan>(type: "interval", nullable: true),
                    Fastestlapq3 = table.Column<TimeSpan>(type: "interval", nullable: true),
                    Position = table.Column<int>(type: "integer", nullable: true),
                    DriverFk = table.Column<int>(type: "integer", nullable: false),
                    RaceFk = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualifyingResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QualifyingResults_Drivers_DriverFk",
                        column: x => x.DriverFk,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QualifyingResults_Races_RaceFk",
                        column: x => x.RaceFk,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QualifyingResults_DriverFk",
                table: "QualifyingResults",
                column: "DriverFk");

            migrationBuilder.CreateIndex(
                name: "IX_QualifyingResults_RaceFk",
                table: "QualifyingResults",
                column: "RaceFk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QualifyingResults");
        }
    }
}
