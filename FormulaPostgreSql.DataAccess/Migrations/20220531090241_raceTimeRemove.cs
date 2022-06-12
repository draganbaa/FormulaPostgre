using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormulaPostgreSql.DataAccess.Migrations
{
    public partial class raceTimeRemove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RaceStartTime",
                table: "Races");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeOnly>(
                name: "RaceStartTime",
                table: "Races",
                type: "time without time zone",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));
        }
    }
}
