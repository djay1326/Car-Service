using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Migrations
{
    public partial class updatecarservicefirstnames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarService_Garage_garageId",
                table: "CarService");

            migrationBuilder.DropForeignKey(
                name: "FK_CarService_AspNetUsers_userId",
                table: "CarService");

            migrationBuilder.RenameColumn(
                name: "wheelBalancing",
                table: "CarService",
                newName: "WheelBalancing");

            migrationBuilder.RenameColumn(
                name: "wheelAlignment",
                table: "CarService",
                newName: "WheelAlignment");

            migrationBuilder.RenameColumn(
                name: "washAndClean",
                table: "CarService",
                newName: "WashAndClean");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "CarService",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "totalCost",
                table: "CarService",
                newName: "TotalCost");

            migrationBuilder.RenameColumn(
                name: "serviceCharge",
                table: "CarService",
                newName: "ServiceCharge");

            migrationBuilder.RenameColumn(
                name: "ratings",
                table: "CarService",
                newName: "Ratings");

            migrationBuilder.RenameColumn(
                name: "ratingDate",
                table: "CarService",
                newName: "RatingDate");

            migrationBuilder.RenameColumn(
                name: "pickupOrDrop",
                table: "CarService",
                newName: "PickupOrDrop");

            migrationBuilder.RenameColumn(
                name: "pickupAndDrop",
                table: "CarService",
                newName: "PickupAndDrop");

            migrationBuilder.RenameColumn(
                name: "oneSidePickOrDrop",
                table: "CarService",
                newName: "OneSidePickOrDrop");

            migrationBuilder.RenameColumn(
                name: "keyRegistration",
                table: "CarService",
                newName: "KeyRegistration");

            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "CarService",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "garageId",
                table: "CarService",
                newName: "GarageId");

            migrationBuilder.RenameColumn(
                name: "carModel",
                table: "CarService",
                newName: "CarModel");

            migrationBuilder.RenameColumn(
                name: "carManufacturer",
                table: "CarService",
                newName: "CarManufacturer");

            migrationBuilder.RenameColumn(
                name: "carFuelType",
                table: "CarService",
                newName: "CarFuelType");

            migrationBuilder.RenameColumn(
                name: "bodyClean",
                table: "CarService",
                newName: "BodyClean");

            migrationBuilder.RenameColumn(
                name: "approxCost",
                table: "CarService",
                newName: "ApproxCost");

            migrationBuilder.RenameColumn(
                name: "appointmentDate",
                table: "CarService",
                newName: "AppointmentDate");

            migrationBuilder.RenameIndex(
                name: "IX_CarService_userId",
                table: "CarService",
                newName: "IX_CarService_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CarService_garageId",
                table: "CarService",
                newName: "IX_CarService_GarageId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarService_Garage_GarageId",
                table: "CarService",
                column: "GarageId",
                principalTable: "Garage",
                principalColumn: "GarageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarService_AspNetUsers_UserId",
                table: "CarService",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarService_Garage_GarageId",
                table: "CarService");

            migrationBuilder.DropForeignKey(
                name: "FK_CarService_AspNetUsers_UserId",
                table: "CarService");

            migrationBuilder.RenameColumn(
                name: "WheelBalancing",
                table: "CarService",
                newName: "wheelBalancing");

            migrationBuilder.RenameColumn(
                name: "WheelAlignment",
                table: "CarService",
                newName: "wheelAlignment");

            migrationBuilder.RenameColumn(
                name: "WashAndClean",
                table: "CarService",
                newName: "washAndClean");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "CarService",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "TotalCost",
                table: "CarService",
                newName: "totalCost");

            migrationBuilder.RenameColumn(
                name: "ServiceCharge",
                table: "CarService",
                newName: "serviceCharge");

            migrationBuilder.RenameColumn(
                name: "Ratings",
                table: "CarService",
                newName: "ratings");

            migrationBuilder.RenameColumn(
                name: "RatingDate",
                table: "CarService",
                newName: "ratingDate");

            migrationBuilder.RenameColumn(
                name: "PickupOrDrop",
                table: "CarService",
                newName: "pickupOrDrop");

            migrationBuilder.RenameColumn(
                name: "PickupAndDrop",
                table: "CarService",
                newName: "pickupAndDrop");

            migrationBuilder.RenameColumn(
                name: "OneSidePickOrDrop",
                table: "CarService",
                newName: "oneSidePickOrDrop");

            migrationBuilder.RenameColumn(
                name: "KeyRegistration",
                table: "CarService",
                newName: "keyRegistration");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "CarService",
                newName: "isActive");

            migrationBuilder.RenameColumn(
                name: "GarageId",
                table: "CarService",
                newName: "garageId");

            migrationBuilder.RenameColumn(
                name: "CarModel",
                table: "CarService",
                newName: "carModel");

            migrationBuilder.RenameColumn(
                name: "CarManufacturer",
                table: "CarService",
                newName: "carManufacturer");

            migrationBuilder.RenameColumn(
                name: "CarFuelType",
                table: "CarService",
                newName: "carFuelType");

            migrationBuilder.RenameColumn(
                name: "BodyClean",
                table: "CarService",
                newName: "bodyClean");

            migrationBuilder.RenameColumn(
                name: "ApproxCost",
                table: "CarService",
                newName: "approxCost");

            migrationBuilder.RenameColumn(
                name: "AppointmentDate",
                table: "CarService",
                newName: "appointmentDate");

            migrationBuilder.RenameIndex(
                name: "IX_CarService_UserId",
                table: "CarService",
                newName: "IX_CarService_userId");

            migrationBuilder.RenameIndex(
                name: "IX_CarService_GarageId",
                table: "CarService",
                newName: "IX_CarService_garageId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarService_Garage_garageId",
                table: "CarService",
                column: "garageId",
                principalTable: "Garage",
                principalColumn: "GarageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarService_AspNetUsers_userId",
                table: "CarService",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
