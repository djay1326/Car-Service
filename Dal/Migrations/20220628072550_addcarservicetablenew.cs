using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Migrations
{
    public partial class addcarservicetablenew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarService",
                columns: table => new
                {
                    CarServiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarAppointmentId = table.Column<int>(nullable: true),
                    ServiceStatus = table.Column<bool>(nullable: true),
                    AcceptDate = table.Column<DateTime>(nullable: true),
                    EstimateDeliveryDate = table.Column<DateTime>(nullable: true),
                    TotalCost = table.Column<int>(nullable: true),
                    Ratings = table.Column<decimal>(nullable: true),
                    RatingsDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarService", x => x.CarServiceId);
                    table.ForeignKey(
                        name: "FK_CarService_CarAppointment_CarAppointmentId",
                        column: x => x.CarAppointmentId,
                        principalTable: "CarAppointment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarService_CarAppointmentId",
                table: "CarService",
                column: "CarAppointmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarService");
        }
    }
}
