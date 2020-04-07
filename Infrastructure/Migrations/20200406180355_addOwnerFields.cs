using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class addOwnerFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailAddress2",
                table: "Owners",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber2",
                table: "Owners",
                maxLength: 25,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber3",
                table: "Owners",
                maxLength: 25,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PropertiesOwned",
                table: "Owners",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Owners",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAddress2",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "PhoneNumber2",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "PhoneNumber3",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "PropertiesOwned",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Owners");
        }
    }
}
