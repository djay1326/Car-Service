using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Migrations
{
    public partial class updategaragefirstnames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Garage_AspNetUsers_userId",
                table: "Garage");

            migrationBuilder.RenameColumn(
                name: "wheelBalancing",
                table: "Garage",
                newName: "WheelBalancing");

            migrationBuilder.RenameColumn(
                name: "wheelAlignment",
                table: "Garage",
                newName: "WheelAlignment");

            migrationBuilder.RenameColumn(
                name: "washAndClean",
                table: "Garage",
                newName: "WashAndClean");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Garage",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "state",
                table: "Garage",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "serviceCharge",
                table: "Garage",
                newName: "ServiceCharge");

            migrationBuilder.RenameColumn(
                name: "postalCode",
                table: "Garage",
                newName: "PostalCode");

            migrationBuilder.RenameColumn(
                name: "pickupOrDrop",
                table: "Garage",
                newName: "PickupOrDrop");

            migrationBuilder.RenameColumn(
                name: "pickupAndDrop",
                table: "Garage",
                newName: "PickupAndDrop");

            migrationBuilder.RenameColumn(
                name: "oneSidePickOrDrop",
                table: "Garage",
                newName: "OneSidePickOrDrop");

            migrationBuilder.RenameColumn(
                name: "keyRegistration",
                table: "Garage",
                newName: "KeyRegistration");

            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "Garage",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "garageName",
                table: "Garage",
                newName: "GarageName");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "Garage",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "bodyClean",
                table: "Garage",
                newName: "BodyClean");

            migrationBuilder.RenameColumn(
                name: "addressLine2",
                table: "Garage",
                newName: "AddressLine2");

            migrationBuilder.RenameColumn(
                name: "addressLine1",
                table: "Garage",
                newName: "AddressLine1");

            migrationBuilder.RenameIndex(
                name: "IX_Garage_userId",
                table: "Garage",
                newName: "IX_Garage_UserId");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Garage",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Garage_AspNetUsers_UserId",
                table: "Garage",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Garage_AspNetUsers_UserId",
                table: "Garage");

            migrationBuilder.RenameColumn(
                name: "WheelBalancing",
                table: "Garage",
                newName: "wheelBalancing");

            migrationBuilder.RenameColumn(
                name: "WheelAlignment",
                table: "Garage",
                newName: "wheelAlignment");

            migrationBuilder.RenameColumn(
                name: "WashAndClean",
                table: "Garage",
                newName: "washAndClean");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Garage",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Garage",
                newName: "state");

            migrationBuilder.RenameColumn(
                name: "ServiceCharge",
                table: "Garage",
                newName: "serviceCharge");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "Garage",
                newName: "postalCode");

            migrationBuilder.RenameColumn(
                name: "PickupOrDrop",
                table: "Garage",
                newName: "pickupOrDrop");

            migrationBuilder.RenameColumn(
                name: "PickupAndDrop",
                table: "Garage",
                newName: "pickupAndDrop");

            migrationBuilder.RenameColumn(
                name: "OneSidePickOrDrop",
                table: "Garage",
                newName: "oneSidePickOrDrop");

            migrationBuilder.RenameColumn(
                name: "KeyRegistration",
                table: "Garage",
                newName: "keyRegistration");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Garage",
                newName: "isActive");

            migrationBuilder.RenameColumn(
                name: "GarageName",
                table: "Garage",
                newName: "garageName");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Garage",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "BodyClean",
                table: "Garage",
                newName: "bodyClean");

            migrationBuilder.RenameColumn(
                name: "AddressLine2",
                table: "Garage",
                newName: "addressLine2");

            migrationBuilder.RenameColumn(
                name: "AddressLine1",
                table: "Garage",
                newName: "addressLine1");

            migrationBuilder.RenameIndex(
                name: "IX_Garage_UserId",
                table: "Garage",
                newName: "IX_Garage_userId");

            migrationBuilder.AlterColumn<bool>(
                name: "isActive",
                table: "Garage",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AddForeignKey(
                name: "FK_Garage_AspNetUsers_userId",
                table: "Garage",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
