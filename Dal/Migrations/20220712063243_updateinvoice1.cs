using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Migrations
{
    public partial class updateinvoice1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceInfo_CarService_CarServiceId",
                table: "InvoiceInfo");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceInfo_CarServiceId",
                table: "InvoiceInfo");

            migrationBuilder.DropColumn(
                name: "CarServiceId",
                table: "InvoiceInfo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarServiceId",
                table: "InvoiceInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceInfo_CarServiceId",
                table: "InvoiceInfo",
                column: "CarServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceInfo_CarService_CarServiceId",
                table: "InvoiceInfo",
                column: "CarServiceId",
                principalTable: "CarService",
                principalColumn: "CarServiceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
