using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Migrations
{
    public partial class NewMechanicService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MechanicService",
                columns: table => new
                {
                    mechanicServiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    carServiceId = table.Column<int>(nullable: true),
                    serviceStatus = table.Column<bool>(nullable: true),
                    AcceptDate = table.Column<DateTime>(nullable: true),
                    estimateDeliveryDate = table.Column<DateTime>(nullable: true),
                    billStatus = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MechanicService", x => x.mechanicServiceId);
                    table.ForeignKey(
                        name: "FK_MechanicService_CarService_carServiceId",
                        column: x => x.carServiceId,
                        principalTable: "CarService",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MechanicService_carServiceId",
                table: "MechanicService",
                column: "carServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MechanicService");
        }
    }
}
