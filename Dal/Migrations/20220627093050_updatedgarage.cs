using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Migrations
{
    public partial class updatedgarage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GarageName",
                table: "Garage",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GarageName",
                table: "Garage");
        }
    }
}
