using Microsoft.EntityFrameworkCore.Migrations;

namespace MSFSAddonsHub.Dal.Data.Migrations
{
    public partial class _10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "039b462b-38bb-45be-8d78-f9c19d53afa0");

            migrationBuilder.AddColumn<string>(
                name: "CustomFileName",
                table: "FileManager",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UploadServiceType",
                table: "FileManager",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ad0904c6-1e07-47c5-990a-a246f01d1766", "bca4cf13-6a56-48e7-bafe-7c1ec22faecc", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad0904c6-1e07-47c5-990a-a246f01d1766");

            migrationBuilder.DropColumn(
                name: "CustomFileName",
                table: "FileManager");

            migrationBuilder.DropColumn(
                name: "UploadServiceType",
                table: "FileManager");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "039b462b-38bb-45be-8d78-f9c19d53afa0", "dc61cd59-1d7d-4c64-9d7b-05a2fc4a58ba", "Admin", "ADMIN" });
        }
    }
}
