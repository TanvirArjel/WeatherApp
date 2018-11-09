using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherApp.DataAccessLayer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    LocationType = table.Column<string>(nullable: true),
                    LatLong = table.Column<string>(nullable: true),
                    WoeId = table.Column<long>(nullable: false),
                    Distance = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "WeatherUpdates",
                columns: table => new
                {
                    WeatherUpdateId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LocationId = table.Column<long>(nullable: false),
                    ApplicableDate = table.Column<DateTime>(nullable: false),
                    WeatherStateName = table.Column<string>(nullable: true),
                    WeatherStateAbbr = table.Column<string>(nullable: true),
                    WindSpeed = table.Column<float>(nullable: false),
                    WindDirection = table.Column<string>(nullable: true),
                    WindDirectionCompass = table.Column<string>(nullable: true),
                    MinTemp = table.Column<decimal>(nullable: false),
                    MaxTemp = table.Column<decimal>(nullable: false),
                    CurrentTemp = table.Column<decimal>(nullable: false),
                    AirPressure = table.Column<float>(nullable: false),
                    Humidity = table.Column<float>(nullable: false),
                    Visibility = table.Column<float>(nullable: false),
                    Predictability = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherUpdates", x => x.WeatherUpdateId);
                    table.ForeignKey(
                        name: "FK_WeatherUpdates_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeatherUpdates_LocationId",
                table: "WeatherUpdates",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherUpdates");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
