using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FormulaPostgreSql.DataAccess.Migrations
{
    public partial class race : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RaceName = table.Column<string>(type: "text", nullable: false),
                    RaceRound = table.Column<int>(type: "integer", nullable: false),
                    RaceStartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    RaceStartTime = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    RaceLaps = table.Column<int>(type: "integer", nullable: false),
                    RaceLength = table.Column<decimal>(type: "numeric", nullable: false),
                    IsSprintQualifying = table.Column<bool>(type: "boolean", nullable: false),
                    TrackFk = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Races_TrackInfos_TrackFk",
                        column: x => x.TrackFk,
                        principalTable: "TrackInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Races_TrackFk",
                table: "Races",
                column: "TrackFk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Races");
        }
    }
}
