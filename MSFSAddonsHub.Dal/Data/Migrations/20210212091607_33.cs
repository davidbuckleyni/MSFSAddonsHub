using Microsoft.EntityFrameworkCore.Migrations;

namespace MSFSAddonsHub.Dal.Data.Migrations
{
    public partial class _33 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6baaed04-e714-44df-b989-77d0af3385b6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d90badea-28fa-4f3d-a030-9bbf09e38ccb", "bcb5b3d4-6d56-48a5-9733-f057183c17a1", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d90badea-28fa-4f3d-a030-9bbf09e38ccb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6baaed04-e714-44df-b989-77d0af3385b6", "90c8de3d-ca2e-4346-9c6d-7d3fadc2f8f7", "Admin", "ADMIN" });
        }
    }
}
