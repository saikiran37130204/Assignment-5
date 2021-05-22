using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherDetailsWebAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "weathers",
                columns: table => new
                {
                    city = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    highTemp = table.Column<double>(type: "float", nullable: false),
                    lowTemp = table.Column<double>(type: "float", nullable: false),
                    forecast = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_weathers", x => x.city);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "weathers");
        }
    }
}
