using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Migrations
{
    public partial class updatecarservice1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalCost",
                table: "CarService");

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "CarService",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comments",
                table: "CarService");

            migrationBuilder.AddColumn<int>(
                name: "TotalCost",
                table: "CarService",
                type: "int",
                nullable: true);
        }
    }
}
