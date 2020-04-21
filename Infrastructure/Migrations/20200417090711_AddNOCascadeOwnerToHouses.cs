using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddNOCascadeOwnerToHouses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Houses_Owners_OwnerId",
                table: "Houses");

            migrationBuilder.AddForeignKey(
                name: "FK_Houses_Owners_OwnerId",
                table: "Houses",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "OwnerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Houses_Owners_OwnerId",
                table: "Houses");

            migrationBuilder.AddForeignKey(
                name: "FK_Houses_Owners_OwnerId",
                table: "Houses",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "OwnerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
