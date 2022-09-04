using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Migrations
{
    public partial class addinovicetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InvoiceInfo",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    GarageId = table.Column<int>(nullable: false),
                    CarServiceId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Mobile = table.Column<int>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Price = table.Column<int>(nullable: true),
                    Tax = table.Column<int>(nullable: true),
                    TotalPrice = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceInfo", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_InvoiceInfo_CarService_CarServiceId",
                        column: x => x.CarServiceId,
                        principalTable: "CarService",
                        principalColumn: "CarServiceId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_InvoiceInfo_Garage_GarageId",
                        column: x => x.GarageId,
                        principalTable: "Garage",
                        principalColumn: "GarageId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_InvoiceInfo_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceInfo_CarServiceId",
                table: "InvoiceInfo",
                column: "CarServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceInfo_GarageId",
                table: "InvoiceInfo",
                column: "GarageId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceInfo_UserId",
                table: "InvoiceInfo",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceInfo");
        }
    }
}
