using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Migrations
{
    public partial class deletealltablesexceptone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceInfo");

            migrationBuilder.DropTable(
                name: "MechanicService");

            migrationBuilder.DropTable(
                name: "Bill");

            migrationBuilder.DropTable(
                name: "CarService");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarService",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApproxCost = table.Column<int>(type: "int", nullable: true),
                    BodyClean = table.Column<int>(type: "int", nullable: true),
                    CarFuelType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarManufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GarageId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    KeyRegistration = table.Column<int>(type: "int", nullable: true),
                    OneSidePickOrDrop = table.Column<int>(type: "int", nullable: true),
                    PickupAndDrop = table.Column<int>(type: "int", nullable: true),
                    PickupOrDrop = table.Column<int>(type: "int", nullable: true),
                    RatingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ratings = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ServiceCharge = table.Column<int>(type: "int", nullable: true),
                    TotalCost = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    WashAndClean = table.Column<int>(type: "int", nullable: true),
                    WheelAlignment = table.Column<int>(type: "int", nullable: true),
                    WheelBalancing = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarService_Garage_GarageId",
                        column: x => x.GarageId,
                        principalTable: "Garage",
                        principalColumn: "GarageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarService_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    billId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    carServiceId = table.Column<int>(type: "int", nullable: true),
                    price = table.Column<int>(type: "int", nullable: true),
                    work = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.billId);
                    table.ForeignKey(
                        name: "FK_Bill_CarService_carServiceId",
                        column: x => x.carServiceId,
                        principalTable: "CarService",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MechanicService",
                columns: table => new
                {
                    mechanicServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    acceptDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    billStatus = table.Column<bool>(type: "bit", nullable: true),
                    carServiceId = table.Column<int>(type: "int", nullable: true),
                    estimateDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    serviceStatus = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MechanicService", x => x.mechanicServiceId);
                    table.ForeignKey(
                        name: "FK_MechanicService_CarService_carServiceId",
                        column: x => x.carServiceId,
                        principalTable: "CarService",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceInfo",
                columns: table => new
                {
                    invoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    billId = table.Column<int>(type: "int", nullable: false),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    finalCost = table.Column<int>(type: "int", nullable: true),
                    garageId = table.Column<int>(type: "int", nullable: false),
                    gst = table.Column<int>(type: "int", nullable: true),
                    mobile = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceInfo", x => x.invoiceId);
                    table.ForeignKey(
                        name: "FK_InvoiceInfo_Bill_billId",
                        column: x => x.billId,
                        principalTable: "Bill",
                        principalColumn: "billId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceInfo_Garage_garageId",
                        column: x => x.garageId,
                        principalTable: "Garage",
                        principalColumn: "GarageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceInfo_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bill_carServiceId",
                table: "Bill",
                column: "carServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_CarService_GarageId",
                table: "CarService",
                column: "GarageId");

            migrationBuilder.CreateIndex(
                name: "IX_CarService_UserId",
                table: "CarService",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceInfo_billId",
                table: "InvoiceInfo",
                column: "billId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceInfo_garageId",
                table: "InvoiceInfo",
                column: "garageId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceInfo_userId",
                table: "InvoiceInfo",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_MechanicService_carServiceId",
                table: "MechanicService",
                column: "carServiceId");
        }
    }
}
