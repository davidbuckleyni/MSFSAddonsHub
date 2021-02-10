using Microsoft.EntityFrameworkCore.Migrations;

namespace MSFSAddonsHub.Dal.Data.Migrations
{
    public partial class _26 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6867fbb0-5d43-4670-b55c-9671ded84f16");

            migrationBuilder.AddColumn<string>(
                name: "GamerTag",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e5368d98-17df-4c18-9b5f-67fb6b5b44ed", "e40bb46b-1429-4828-bef4-51f773027a6a", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5368d98-17df-4c18-9b5f-67fb6b5b44ed");

            migrationBuilder.DropColumn(
                name: "GamerTag",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6867fbb0-5d43-4670-b55c-9671ded84f16", "dc725084-852c-4e96-9cd0-26a8c518c0d4", "Admin", "ADMIN" });
        }
    }
}
