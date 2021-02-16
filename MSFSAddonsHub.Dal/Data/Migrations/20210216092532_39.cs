using Microsoft.EntityFrameworkCore.Migrations;

namespace MSFSAddonsHub.Dal.Data.Migrations
{
    public partial class _39 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c03b6b47-44e8-45ea-a78f-f6123bac7c81");

            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "ClubUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AvatarImage",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6220cd5d-6420-4a82-9cd5-7f893fd5f854", "eb09bb91-155b-4cab-affb-e4241742572b", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6220cd5d-6420-4a82-9cd5-7f893fd5f854");

            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "ClubUsers");

            migrationBuilder.DropColumn(
                name: "AvatarImage",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c03b6b47-44e8-45ea-a78f-f6123bac7c81", "f40654c4-03f0-4480-9acd-ab6664d5458a", "Admin", "ADMIN" });
        }
    }
}
