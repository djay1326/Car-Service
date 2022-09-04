using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Migrations
{
    public partial class updateServiceWork1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarManufacturerId",
                table: "ServiceWork",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Garage",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceWork_CarManufacturerId",
                table: "ServiceWork",
                column: "CarManufacturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceWork_CarAppointment_CarManufacturerId",
                table: "ServiceWork",
                column: "CarManufacturerId",
                principalTable: "CarAppointment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceWork_CarAppointment_CarManufacturerId",
                table: "ServiceWork");

            migrationBuilder.DropIndex(
                name: "IX_ServiceWork_CarManufacturerId",
                table: "ServiceWork");

            migrationBuilder.DropColumn(
                name: "CarManufacturerId",
                table: "ServiceWork");

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Garage",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
