using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MSFSAddonsHub.Dal.Data.Migrations
{
    public partial class _35 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fdf8f13c-fcca-4de0-bba9-2c488d0e3604");

            migrationBuilder.AddColumn<DateTime>(
                name: "BannedEndDateTime",
                table: "ClubUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BannedStartDateTime",
                table: "ClubUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ClubUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ClubUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "ClubUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isBanned",
                table: "ClubUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "ClubUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cbafa33b-39c7-4341-9dd3-28fb40d6edc6", "0d10fc66-c2d9-493b-bc74-33b4b7a45335", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbafa33b-39c7-4341-9dd3-28fb40d6edc6");

            migrationBuilder.DropColumn(
                name: "BannedEndDateTime",
                table: "ClubUsers");

            migrationBuilder.DropColumn(
                name: "BannedStartDateTime",
                table: "ClubUsers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ClubUsers");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ClubUsers");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "ClubUsers");

            migrationBuilder.DropColumn(
                name: "isBanned",
                table: "ClubUsers");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "ClubUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fdf8f13c-fcca-4de0-bba9-2c488d0e3604", "fcd14d61-0632-4db7-a555-f92351c6dab8", "Admin", "ADMIN" });
        }
    }
}
