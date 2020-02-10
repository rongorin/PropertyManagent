using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class CollectionOfIvoicesForHouse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Invoices_HouseId",
                table: "Invoices",
                column: "HouseId");

          

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Houses_HouseId",
                table: "Invoices",
                column: "HouseId",
                principalTable: "Houses",
                principalColumn: "HouseId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Houses_Owners_OwnerId",
                table: "Houses");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Houses_HouseId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_HouseId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Houses_OwnerId",
                table: "Houses");
        }
    }
}
