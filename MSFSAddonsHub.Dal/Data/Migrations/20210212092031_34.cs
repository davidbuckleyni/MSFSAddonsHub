using Microsoft.EntityFrameworkCore.Migrations;

namespace MSFSAddonsHub.Dal.Data.Migrations
{
    public partial class _34 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClubUsers_AspNetUsers_UserId1",
                table: "ClubUsers");

            migrationBuilder.DropIndex(
                name: "IX_ClubUsers_UserId1",
                table: "ClubUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d90badea-28fa-4f3d-a030-9bbf09e38ccb");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "ClubUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ClubUsers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fdf8f13c-fcca-4de0-bba9-2c488d0e3604", "fcd14d61-0632-4db7-a555-f92351c6dab8", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_ClubUsers_UserId",
                table: "ClubUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClubUsers_AspNetUsers_UserId",
                table: "ClubUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClubUsers_AspNetUsers_UserId",
                table: "ClubUsers");

            migrationBuilder.DropIndex(
                name: "IX_ClubUsers_UserId",
                table: "ClubUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fdf8f13c-fcca-4de0-bba9-2c488d0e3604");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ClubUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "ClubUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d90badea-28fa-4f3d-a030-9bbf09e38ccb", "bcb5b3d4-6d56-48a5-9733-f057183c17a1", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_ClubUsers_UserId1",
                table: "ClubUsers",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ClubUsers_AspNetUsers_UserId1",
                table: "ClubUsers",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
