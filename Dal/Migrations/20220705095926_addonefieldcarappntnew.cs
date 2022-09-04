using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Migrations
{
    public partial class addonefieldcarappntnew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CarName",
                table: "CarAppointment",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarName",
                table: "CarAppointment");
        }
    }
}
