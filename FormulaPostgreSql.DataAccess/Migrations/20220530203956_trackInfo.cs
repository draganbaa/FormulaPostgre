using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FormulaPostgreSql.DataAccess.Migrations
{
    public partial class trackInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrackInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Trackname = table.Column<string>(type: "text", nullable: false),
                    Turns = table.Column<int>(type: "integer", nullable: false),
                    Tracklength = table.Column<decimal>(type: "numeric", nullable: false),
                    LocationFk = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrackInfos_LocationInfos_LocationFk",
                        column: x => x.LocationFk,
                        principalTable: "LocationInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrackInfos_LocationFk",
                table: "TrackInfos",
                column: "LocationFk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrackInfos");
        }
    }
}
