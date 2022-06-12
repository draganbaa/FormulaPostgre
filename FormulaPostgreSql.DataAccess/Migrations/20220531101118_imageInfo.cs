using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FormulaPostgreSql.DataAccess.Migrations
{
    public partial class imageInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImageInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    ImageDescription = table.Column<string>(type: "text", nullable: true),
                    TeamFk = table.Column<int>(type: "integer", nullable: false),
                    DriverFk = table.Column<int>(type: "integer", nullable: false),
                    TrackFk = table.Column<int>(type: "integer", nullable: false),
                    CountryFk = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageInfos_Country_CountryFk",
                        column: x => x.CountryFk,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageInfos_Drivers_DriverFk",
                        column: x => x.DriverFk,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageInfos_Teams_TeamFk",
                        column: x => x.TeamFk,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageInfos_TrackInfos_TrackFk",
                        column: x => x.TrackFk,
                        principalTable: "TrackInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageInfos_CountryFk",
                table: "ImageInfos",
                column: "CountryFk");

            migrationBuilder.CreateIndex(
                name: "IX_ImageInfos_DriverFk",
                table: "ImageInfos",
                column: "DriverFk");

            migrationBuilder.CreateIndex(
                name: "IX_ImageInfos_TeamFk",
                table: "ImageInfos",
                column: "TeamFk");

            migrationBuilder.CreateIndex(
                name: "IX_ImageInfos_TrackFk",
                table: "ImageInfos",
                column: "TrackFk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageInfos");
        }
    }
}
