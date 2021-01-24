using Microsoft.EntityFrameworkCore.Migrations;

namespace MSFSAddonsHub.Dal.Data.Migrations
{
    public partial class _11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad0904c6-1e07-47c5-990a-a246f01d1766");

            migrationBuilder.AddColumn<string>(
                name: "HttpDownloadUrl",
                table: "FileManager",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "60e7e21a-0104-4928-bf11-075c2e8a2145", "8cc26d84-d1ec-4c75-a9e9-b5cd2a77c1c8", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60e7e21a-0104-4928-bf11-075c2e8a2145");

            migrationBuilder.DropColumn(
                name: "HttpDownloadUrl",
                table: "FileManager");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ad0904c6-1e07-47c5-990a-a246f01d1766", "bca4cf13-6a56-48e7-bafe-7c1ec22faecc", "Admin", "ADMIN" });
        }
    }
}
