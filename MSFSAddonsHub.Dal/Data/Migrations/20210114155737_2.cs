using Microsoft.EntityFrameworkCore.Migrations;

namespace MSFSAddonsHub.Dal.Data.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAddons_UserAddons_UserAddonId",
                table: "UserAddons");

            migrationBuilder.DropIndex(
                name: "IX_UserAddons_UserAddonId",
                table: "UserAddons");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "efa162f4-c7f6-4067-b55f-ff96382720b4");

            migrationBuilder.DropColumn(
                name: "MyserAddonId",
                table: "UserAddons");

            migrationBuilder.DropColumn(
                name: "UserAddonId",
                table: "UserAddons");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "517bfbf8-4ef7-4eb9-b8fd-9aefafa563a0", "7a904911-4a11-4c72-903b-d447ffc1bfc2", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "517bfbf8-4ef7-4eb9-b8fd-9aefafa563a0");

            migrationBuilder.AddColumn<int>(
                name: "MyserAddonId",
                table: "UserAddons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserAddonId",
                table: "UserAddons",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "efa162f4-c7f6-4067-b55f-ff96382720b4", "a23a12f0-8446-4222-a9a2-fad77716a18f", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_UserAddons_UserAddonId",
                table: "UserAddons",
                column: "UserAddonId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddons_UserAddons_UserAddonId",
                table: "UserAddons",
                column: "UserAddonId",
                principalTable: "UserAddons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
