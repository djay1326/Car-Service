using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Migrations
{
    public partial class updateCarServicedata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceStatus",
                table: "CarService");

            migrationBuilder.AddColumn<int>(
                name: "PaymentStatus",
                table: "CarService",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "CarService");

            migrationBuilder.AddColumn<bool>(
                name: "ServiceStatus",
                table: "CarService",
                type: "bit",
                nullable: true);
        }
    }
}
