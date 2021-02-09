using Microsoft.EntityFrameworkCore.Migrations;

namespace MSFSAddonsHub.Dal.Data.Migrations
{
    public partial class _20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79345df5-86bd-4192-8f90-32b70dca09d0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "07e6ad56-e286-4112-870b-e4321596dfaa", "ab5c87c2-7a1a-4e50-8f13-0279478aa58b", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07e6ad56-e286-4112-870b-e4321596dfaa");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "79345df5-86bd-4192-8f90-32b70dca09d0", "8eaf7f23-b12b-4677-aa04-789b81843bb3", "Admin", "ADMIN" });
        }
    }
}
