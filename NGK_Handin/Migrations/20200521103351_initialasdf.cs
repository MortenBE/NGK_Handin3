using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NGK_Handin3.Migrations
{
    public partial class initialasdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "WeatherObservations",
                nullable: false,
                defaultValueSql: "getutcdate()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "WeatherObservations");
        }
    }
}
