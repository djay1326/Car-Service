using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Migrations
{
    public partial class deletetwotables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "package");

            migrationBuilder.DropTable(
                name: "UserAddress");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "package",
                columns: table => new
                {
                    PackageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    bodyClean = table.Column<int>(type: "int", nullable: true),
                    keyRegistration = table.Column<int>(type: "int", nullable: true),
                    oneSidePickOrDrop = table.Column<int>(type: "int", nullable: true),
                    pickupAndDrop = table.Column<int>(type: "int", nullable: true),
                    pickupOrDrop = table.Column<int>(type: "int", nullable: true),
                    serviceCharge = table.Column<int>(type: "int", nullable: true),
                    washAndClean = table.Column<int>(type: "int", nullable: true),
                    wheelAlignment = table.Column<int>(type: "int", nullable: true),
                    wheelBalancing = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "UserAddress",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddress", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_UserAddress_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_package_UserId",
                table: "package",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddress_UserId",
                table: "UserAddress",
                column: "UserId");
        }
    }
}
