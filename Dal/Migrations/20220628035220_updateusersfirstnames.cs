using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Migrations
{
    public partial class updateusersfirstnames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "state",
                table: "AspNetUsers",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "postalCode",
                table: "AspNetUsers",
                newName: "PostalCode");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "AspNetUsers",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "addressLine2",
                table: "AspNetUsers",
                newName: "AddressLine2");

            migrationBuilder.RenameColumn(
                name: "addressLine1",
                table: "AspNetUsers",
                newName: "AddressLine1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "State",
                table: "AspNetUsers",
                newName: "state");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "AspNetUsers",
                newName: "postalCode");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "AspNetUsers",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "AddressLine2",
                table: "AspNetUsers",
                newName: "addressLine2");

            migrationBuilder.RenameColumn(
                name: "AddressLine1",
                table: "AspNetUsers",
                newName: "addressLine1");
        }
    }
}
