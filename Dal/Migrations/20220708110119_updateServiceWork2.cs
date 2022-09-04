using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Migrations
{
    public partial class updateServiceWork2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "CarAppointmentId",
                table: "ServiceWork",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceWork_CarAppointmentId",
                table: "ServiceWork",
                column: "CarAppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceWork_CarAppointment_CarAppointmentId",
                table: "ServiceWork",
                column: "CarAppointmentId",
                principalTable: "CarAppointment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceWork_CarAppointment_CarAppointmentId",
                table: "ServiceWork");

            migrationBuilder.DropIndex(
                name: "IX_ServiceWork_CarAppointmentId",
                table: "ServiceWork");

            migrationBuilder.DropColumn(
                name: "CarAppointmentId",
                table: "ServiceWork");

            migrationBuilder.AddColumn<int>(
                name: "CarManufacturerId",
                table: "ServiceWork",
                type: "int",
                nullable: true);

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
    }
}
