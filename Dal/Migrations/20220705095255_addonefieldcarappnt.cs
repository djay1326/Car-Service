using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Migrations
{
    public partial class addonefieldcarappnt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarNumber",
                table: "Garage");

            migrationBuilder.AddColumn<string>(
                name: "CarNumber",
                table: "CarAppointment",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarNumber",
                table: "CarAppointment");

            migrationBuilder.AddColumn<string>(
                name: "CarNumber",
                table: "Garage",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
