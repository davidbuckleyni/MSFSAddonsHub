using Microsoft.EntityFrameworkCore.Migrations;

namespace MSFSAddonsHub.Dal.Data.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "517bfbf8-4ef7-4eb9-b8fd-9aefafa563a0");

            migrationBuilder.AddColumn<string>(
                name: "FlightPlanXML",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8abdaaae-a21e-46c4-9010-0ff9c3045704", "460c3756-b8a4-4376-8eac-c3fa18de04d4", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_ClubId",
                table: "Flights",
                column: "ClubId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Clubs_ClubId",
                table: "Flights",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Clubs_ClubId",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_ClubId",
                table: "Flights");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8abdaaae-a21e-46c4-9010-0ff9c3045704");

            migrationBuilder.DropColumn(
                name: "FlightPlanXML",
                table: "Flights");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "517bfbf8-4ef7-4eb9-b8fd-9aefafa563a0", "7a904911-4a11-4c72-903b-d447ffc1bfc2", "Admin", "ADMIN" });
        }
    }
}
