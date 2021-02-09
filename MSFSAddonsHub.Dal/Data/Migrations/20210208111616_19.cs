using Microsoft.EntityFrameworkCore.Migrations;

namespace MSFSAddonsHub.Dal.Data.Migrations
{
    public partial class _19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d030e2d9-d186-4d37-8ef0-3b4c28875fcd");

            migrationBuilder.AddColumn<int>(
                name: "ClubId1",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "79345df5-86bd-4192-8f90-32b70dca09d0", "8eaf7f23-b12b-4677-aa04-789b81843bb3", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ClubId1",
                table: "AspNetUsers",
                column: "ClubId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Clubs_ClubId1",
                table: "AspNetUsers",
                column: "ClubId1",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Clubs_ClubId1",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ClubId1",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79345df5-86bd-4192-8f90-32b70dca09d0");

            migrationBuilder.DropColumn(
                name: "ClubId1",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d030e2d9-d186-4d37-8ef0-3b4c28875fcd", "acdf672b-aac5-4fff-b5ad-4eceebeeb0ee", "Admin", "ADMIN" });
        }
    }
}
