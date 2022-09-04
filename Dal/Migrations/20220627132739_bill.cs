using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Migrations
{
    public partial class bill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Ratings",
                table: "CarService",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    billId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    carServiceId = table.Column<int>(nullable: true),
                    work = table.Column<string>(nullable: true),
                    price = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.billId);
                    table.ForeignKey(
                        name: "FK_Bill_CarService_carServiceId",
                        column: x => x.carServiceId,
                        principalTable: "CarService",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bill_carServiceId",
                table: "Bill",
                column: "carServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bill");

            migrationBuilder.AlterColumn<decimal>(
                name: "Ratings",
                table: "CarService",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);
        }
    }
}
