using Microsoft.EntityFrameworkCore.Migrations;

namespace MSFSAddonsHub.Dal.Data.Migrations
{
    public partial class _29 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a32c3cf-1d07-4c59-8f06-c2d3767100f9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "928d5219-7f06-43d6-8f32-aa0077d28fd4", "91bab6ba-a240-4dca-ac54-1adcf3f7f69a", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "928d5219-7f06-43d6-8f32-aa0077d28fd4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0a32c3cf-1d07-4c59-8f06-c2d3767100f9", "85696ab2-103a-4782-9143-fa3956fbcdb3", "Admin", "ADMIN" });
        }
    }
}
