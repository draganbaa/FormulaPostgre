using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FormulaPostgreSql.DataAccess.Migrations
{
    public partial class teams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TeamName = table.Column<string>(type: "text", nullable: false),
                    TeamChief = table.Column<string>(type: "text", nullable: false),
                    Chassis = table.Column<string>(type: "text", nullable: false),
                    PowerUnit = table.Column<string>(type: "text", nullable: false),
                    CountryFk = table.Column<int>(type: "integer", nullable: false),
                    LocationFk = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Country_CountryFk",
                        column: x => x.CountryFk,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teams_LocationInfos_LocationFk",
                        column: x => x.LocationFk,
                        principalTable: "LocationInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CountryFk",
                table: "Teams",
                column: "CountryFk");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_LocationFk",
                table: "Teams",
                column: "LocationFk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
