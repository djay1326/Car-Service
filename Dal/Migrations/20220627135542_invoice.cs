using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Migrations
{
    public partial class invoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "InvoiceInfo",
                columns: table => new
                {
                    invoiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(nullable: false),
                    garageId = table.Column<int>(nullable: false),
                    billId = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    mobile = table.Column<int>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    createdDate = table.Column<DateTime>(nullable: true),
                    gst = table.Column<int>(nullable: true),
                    finalCost = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceInfo", x => x.invoiceId);
                    table.ForeignKey(
                        name: "FK_InvoiceInfo_Bill_billId",
                        column: x => x.billId,
                        principalTable: "Bill",
                        principalColumn: "billId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_InvoiceInfo_Garage_garageId",
                        column: x => x.garageId,
                        principalTable: "Garage",
                        principalColumn: "GarageId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_InvoiceInfo_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceInfo_billId",
                table: "InvoiceInfo",
                column: "billId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceInfo_garageId",
                table: "InvoiceInfo",
                column: "garageId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceInfo_userId",
                table: "InvoiceInfo",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceInfo");

            

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_billId",
                table: "Invoice",
                column: "billId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_garageId",
                table: "Invoice",
                column: "garageId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_userId",
                table: "Invoice",
                column: "userId");
        }
    }
}
