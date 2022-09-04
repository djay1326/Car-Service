using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Migrations
{
    public partial class updateCarAppointment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RatingDate",
                table: "CarAppointment");

            migrationBuilder.DropColumn(
                name: "Ratings",
                table: "CarAppointment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RatingDate",
                table: "CarAppointment",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Ratings",
                table: "CarAppointment",
                type: "decimal(18,2)",
                nullable: true);
        }
    }
}
