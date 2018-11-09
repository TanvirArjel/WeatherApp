using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherApp.DataAccessLayer.Migrations
{
    public partial class LatestUpdateTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LatestUpdates",
                columns: table => new
                {
                    LocationId = table.Column<long>(nullable: false),
                    ApplicableDate = table.Column<DateTime>(nullable: false),
                    WeatherStateName = table.Column<string>(nullable: true),
                    WeatherStateAbbr = table.Column<string>(nullable: true),
                    WindSpeed = table.Column<float>(nullable: false),
                    WindDirection = table.Column<float>(nullable: false),
                    WindDirectionCompass = table.Column<string>(nullable: true),
                    MinTemp = table.Column<float>(nullable: false),
                    MaxTemp = table.Column<float>(nullable: false),
                    CurrentTemp = table.Column<float>(nullable: false),
                    AirPressure = table.Column<float>(nullable: false),
                    Humidity = table.Column<float>(nullable: false),
                    Visibility = table.Column<float>(nullable: false),
                    Predictability = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LatestUpdates", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_LatestUpdates_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LatestUpdates");
        }
    }
}
