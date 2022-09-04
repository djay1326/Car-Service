using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Migrations
{
    public partial class carservice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Garage",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.CreateTable(
                name: "CarService",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    GarageId = table.Column<int>(nullable: false),
                    carManufacturer = table.Column<string>(nullable: true),
                    carModel = table.Column<string>(nullable: true),
                    carFuelType = table.Column<string>(nullable: true),
                    AppointmentDate = table.Column<DateTime>(nullable: true),
                    ApproxCost = table.Column<int>(nullable: true),
                    TotalCost = table.Column<int>(nullable: true),
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
                    KeyRegistration = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarService_Garage_GarageId",
                        column: x => x.GarageId,
                        principalTable: "Garage",
                        principalColumn: "GarageId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CarService_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarService_GarageId",
                table: "CarService",
                column: "GarageId");

            migrationBuilder.CreateIndex(
                name: "IX_CarService_UserId",
                table: "CarService",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarService");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Garage",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);
        }
    }
}
