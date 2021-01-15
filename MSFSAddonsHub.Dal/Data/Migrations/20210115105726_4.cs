using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MSFSAddonsHub.Dal.Data.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8abdaaae-a21e-46c4-9010-0ff9c3045704");

            migrationBuilder.AddColumn<Guid>(
                name: "ClubId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e41a2d51-f5b9-4a5b-b951-78d00372ab8d", "bbe2feb0-07a3-4b45-8c17-d1276cdb3473", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e41a2d51-f5b9-4a5b-b951-78d00372ab8d");

            migrationBuilder.DropColumn(
                name: "ClubId",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8abdaaae-a21e-46c4-9010-0ff9c3045704", "460c3756-b8a4-4376-8eac-c3fa18de04d4", "Admin", "ADMIN" });
        }
    }
}
