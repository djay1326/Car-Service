using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Migrations
{
    public partial class MechanicService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarService_AspNetUsers_UserId",
                table: "CarService");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "CarService",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Ratings",
                table: "CarService",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CarService_AspNetUsers_UserId",
                table: "CarService",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarService_AspNetUsers_UserId",
                table: "CarService");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "CarService",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Ratings",
                table: "CarService",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AddForeignKey(
                name: "FK_CarService_AspNetUsers_UserId",
                table: "CarService",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
