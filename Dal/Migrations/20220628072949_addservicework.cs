using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Migrations
{
    public partial class addservicework : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceWork",
                columns: table => new
                {
                    WorkId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarServiceId = table.Column<int>(nullable: true),
                    Work = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceWork", x => x.WorkId);
                    table.ForeignKey(
                        name: "FK_ServiceWork_CarService_CarServiceId",
                        column: x => x.CarServiceId,
                        principalTable: "CarService",
                        principalColumn: "CarServiceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceWork_CarServiceId",
                table: "ServiceWork",
                column: "CarServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceWork");
        }
    }
}
