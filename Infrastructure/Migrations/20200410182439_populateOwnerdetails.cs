using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class populateOwnerdetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 1,
                columns: new[] { "PhoneNumber2", "Title" },
                values: new object[] { "0943342423", "Mr" });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 2,
                columns: new[] { "PhoneNumber2", "Title" },
                values: new object[] { "0943342423", "Mr" });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 3,
                columns: new[] { "EmailAddress2", "PhoneNumber2", "Title" },
                values: new object[] { "sds22A@gmail.com", "0943342423", "Mrs" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 1,
                columns: new[] { "PhoneNumber2", "Title" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 2,
                columns: new[] { "PhoneNumber2", "Title" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 3,
                columns: new[] { "EmailAddress2", "PhoneNumber2", "Title" },
                values: new object[] { null, null, null });
        }
    }
}
