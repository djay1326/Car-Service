using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Migrations
{
    public partial class garagedetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Garage",
                columns: table => new
                {
                    GarageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    PickupOrDrop = table.Column<int>(nullable: true),
                    ServiceCharge = table.Column<int>(nullable: true),
                    WheelBalancing = table.Column<int>(nullable: true),
                    WheelAlignment = table.Column<int>(nullable: true),
                    WashAndClean = table.Column<int>(nullable: true),
                    BodyClean = table.Column<int>(nullable: true),
                    PickupAndDrop = table.Column<int>(nullable: true),
                    OneSidePickOrDrop = table.Column<int>(nullable: true),
                    KeyRegistration = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garage", x => x.GarageId);
                    table.ForeignKey(
                        name: "FK_Garage_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Garage_UserId",
                table: "Garage",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Garage");
        }
    }
}
