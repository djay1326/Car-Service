using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Migrations
{
    public partial class allpackages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "package",
                columns: table => new
                {
                    PackageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    pickupOrDrop = table.Column<int>(nullable: true),
                    serviceCharge = table.Column<int>(nullable: true),
                    wheelBalancing = table.Column<int>(nullable: true),
                    wheelAlignment = table.Column<int>(nullable: true),
                    washAndClean = table.Column<int>(nullable: true),
                    bodyClean = table.Column<int>(nullable: true),
                    pickupAndDrop = table.Column<int>(nullable: true),
                    oneSidePickOrDrop = table.Column<int>(nullable: true),
                    keyRegistration = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_package", x => x.PackageId);
                    table.ForeignKey(
                        name: "FK_package_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_package_UserId",
                table: "package",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "package");

            
        }
    }
}
