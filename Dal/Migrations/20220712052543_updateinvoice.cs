using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Migrations
{
    public partial class updateinvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "InvoiceInfo",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PostalCode",
                table: "InvoiceInfo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "InvoiceInfo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "InvoiceInfo");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "InvoiceInfo");

            migrationBuilder.DropColumn(
                name: "State",
                table: "InvoiceInfo");
        }
    }
}
