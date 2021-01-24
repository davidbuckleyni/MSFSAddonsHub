using Microsoft.EntityFrameworkCore.Migrations;

namespace MSFSAddonsHub.Dal.Data.Migrations
{
    public partial class _12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60e7e21a-0104-4928-bf11-075c2e8a2145");

            migrationBuilder.AddColumn<string>(
                name: "DestAirportCode",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FlightPlanUrl",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StartAirportCode",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f9fcd2d4-2b0c-4482-b85b-6092d3ac1072", "956f56b5-45db-427a-acd5-819852bbe7c3", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9fcd2d4-2b0c-4482-b85b-6092d3ac1072");

            migrationBuilder.DropColumn(
                name: "DestAirportCode",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "FlightPlanUrl",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "StartAirportCode",
                table: "Flights");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "60e7e21a-0104-4928-bf11-075c2e8a2145", "8cc26d84-d1ec-4c75-a9e9-b5cd2a77c1c8", "Admin", "ADMIN" });
        }
    }
}
