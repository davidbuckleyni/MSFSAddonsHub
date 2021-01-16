using Microsoft.EntityFrameworkCore.Migrations;

namespace MSFSAddonsHub.Dal.Data.Migrations
{
    public partial class _8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0fc348a9-ee62-4885-8ece-63d7dda0af68");

            migrationBuilder.AddColumn<string>(
                name: "OrignalFilename",
                table: "FileManager",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "580b9c1d-425e-4eef-adb4-c8ca0cd6a6a3", "cc759025-17d0-4b05-98b9-478816fd85dc", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "580b9c1d-425e-4eef-adb4-c8ca0cd6a6a3");

            migrationBuilder.DropColumn(
                name: "OrignalFilename",
                table: "FileManager");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0fc348a9-ee62-4885-8ece-63d7dda0af68", "aa644244-2849-4e40-b20e-1e363d55b9e1", "Admin", "ADMIN" });
        }
    }
}
