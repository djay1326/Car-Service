using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Migrations
{
    public partial class addtwonewtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarManufacturers",
                columns: table => new
                {
                    CarManufacturerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfCar = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarManufacturers", x => x.CarManufacturerId);
                });

            migrationBuilder.CreateTable(
                name: "CarAppointment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: true),
                    GarageId = table.Column<int>(nullable: false),
                    CarManufacturerId = table.Column<int>(nullable: true),
                    CarModel = table.Column<string>(nullable: true),
                    CarFuelType = table.Column<int>(nullable: true),
                    AppointmentDate = table.Column<DateTime>(nullable: true),
                    ApproxCost = table.Column<int>(nullable: true),
                    Ratings = table.Column<decimal>(nullable: true),
                    RatingDate = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    PickupOrDrop = table.Column<int>(nullable: true),
                    ServiceCharge = table.Column<int>(nullable: true),
                    WheelBalancing = table.Column<int>(nullable: true),
                    WheelAlignment = table.Column<int>(nullable: true),
                    WashAndClean = table.Column<int>(nullable: true),
                    BodyClean = table.Column<int>(nullable: true),
                    PickupAndDrop = table.Column<int>(nullable: true),
                    OneSidePickOrDrop = table.Column<int>(nullable: true),
                    KeyRegistration = table.Column<int>(nullable: true),
                    ServiceStatus = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarAppointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarAppointment_CarManufacturers_CarManufacturerId",
                        column: x => x.CarManufacturerId,
                        principalTable: "CarManufacturers",
                        principalColumn: "CarManufacturerId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CarAppointment_Garage_GarageId",
                        column: x => x.GarageId,
                        principalTable: "Garage",
                        principalColumn: "GarageId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CarAppointment_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarAppointment_CarManufacturerId",
                table: "CarAppointment",
                column: "CarManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_CarAppointment_GarageId",
                table: "CarAppointment",
                column: "GarageId");

            migrationBuilder.CreateIndex(
                name: "IX_CarAppointment_UserId",
                table: "CarAppointment",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarAppointment");

            migrationBuilder.DropTable(
                name: "CarManufacturers");
        }
    }
}
