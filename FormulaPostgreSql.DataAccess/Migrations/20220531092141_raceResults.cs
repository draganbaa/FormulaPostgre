using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FormulaPostgreSql.DataAccess.Migrations
{
    public partial class raceResults : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RaceStartDate",
                table: "Races",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.CreateTable(
                name: "RaceResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FinalPosition = table.Column<int>(type: "integer", nullable: false),
                    FastestLap = table.Column<TimeSpan>(type: "interval", nullable: false),
                    LapsFinished = table.Column<int>(type: "integer", nullable: true),
                    RaceTime = table.Column<string>(type: "text", nullable: true),
                    PointsGained = table.Column<int>(type: "integer", nullable: true),
                    DriverFk = table.Column<int>(type: "integer", nullable: false),
                    RaceFk = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RaceResults_Drivers_DriverFk",
                        column: x => x.DriverFk,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RaceResults_Races_RaceFk",
                        column: x => x.RaceFk,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RaceResults_DriverFk",
                table: "RaceResults",
                column: "DriverFk");

            migrationBuilder.CreateIndex(
                name: "IX_RaceResults_RaceFk",
                table: "RaceResults",
                column: "RaceFk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RaceResults");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RaceStartDate",
                table: "Races",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");
        }
    }
}
