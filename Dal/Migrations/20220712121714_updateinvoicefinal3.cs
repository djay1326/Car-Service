using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Migrations
{
    public partial class updateinvoicefinal3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarAppointmentId",
                table: "InvoiceInfo",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceInfo_CarAppointmentId",
                table: "InvoiceInfo",
                column: "CarAppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceInfo_CarAppointment_CarAppointmentId",
                table: "InvoiceInfo",
                column: "CarAppointmentId",
                principalTable: "CarAppointment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceInfo_CarAppointment_CarAppointmentId",
                table: "InvoiceInfo");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceInfo_CarAppointmentId",
                table: "InvoiceInfo");

            migrationBuilder.DropColumn(
                name: "CarAppointmentId",
                table: "InvoiceInfo");
        }
    }
}
