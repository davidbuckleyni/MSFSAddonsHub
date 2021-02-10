using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MSFSAddonsHub.Dal.Data.Migrations
{
    public partial class _28 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "947cc9b8-5773-484a-ad18-779711f56c11");

            migrationBuilder.AlterColumn<Guid>(
                name: "ClubId",
                table: "Clubs",
                type: "uniqueidentifier",
                nullable: true,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0a32c3cf-1d07-4c59-8f06-c2d3767100f9", "85696ab2-103a-4782-9143-fa3956fbcdb3", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a32c3cf-1d07-4c59-8f06-c2d3767100f9");

            migrationBuilder.AlterColumn<Guid>(
                name: "ClubId",
                table: "Clubs",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "947cc9b8-5773-484a-ad18-779711f56c11", "c617bb3c-516f-49b4-b44d-c8d306c3d58d", "Admin", "ADMIN" });
        }
    }
}
