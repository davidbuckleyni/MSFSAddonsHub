using Microsoft.EntityFrameworkCore.Migrations;

namespace MSFSAddonsHub.Dal.Data.Migrations
{
    public partial class _5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e41a2d51-f5b9-4a5b-b951-78d00372ab8d");

            migrationBuilder.AddColumn<bool>(
                name: "isOnline",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "657f0950-9129-4311-bd77-9e1f36005d65", "499312f0-0900-4f3e-ba89-92fde1248a14", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "657f0950-9129-4311-bd77-9e1f36005d65");

            migrationBuilder.DropColumn(
                name: "isOnline",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e41a2d51-f5b9-4a5b-b951-78d00372ab8d", "bbe2feb0-07a3-4b45-8c17-d1276cdb3473", "Admin", "ADMIN" });
        }
    }
}
