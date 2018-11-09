using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherApp.DataAccessLayer.Migrations
{
    public partial class LocationModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Distance",
                table: "Locations");

            migrationBuilder.AlterColumn<float>(
                name: "WindDirection",
                table: "WeatherUpdates",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "MinTemp",
                table: "WeatherUpdates",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<float>(
                name: "MaxTemp",
                table: "WeatherUpdates",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<float>(
                name: "CurrentTemp",
                table: "WeatherUpdates",
                nullable: false,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "WindDirection",
                table: "WeatherUpdates",
                nullable: true,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<decimal>(
                name: "MinTemp",
                table: "WeatherUpdates",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<decimal>(
                name: "MaxTemp",
                table: "WeatherUpdates",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<decimal>(
                name: "CurrentTemp",
                table: "WeatherUpdates",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AddColumn<long>(
                name: "Distance",
                table: "Locations",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
