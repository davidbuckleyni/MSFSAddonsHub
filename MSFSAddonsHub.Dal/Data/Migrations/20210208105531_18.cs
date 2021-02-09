using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MSFSAddonsHub.Dal.Data.Migrations
{
    public partial class _18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53291b98-cc3b-4eb2-9864-cbbb0ab7693d");

            migrationBuilder.AlterColumn<bool>(
                name: "isGpdrRemoveRequest",
                table: "Clubs",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "isBanned",
                table: "Clubs",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "BannedTime",
                table: "Clubs",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "BanPeriod",
                table: "Clubs",
                type: "time",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d030e2d9-d186-4d37-8ef0-3b4c28875fcd", "acdf672b-aac5-4fff-b5ad-4eceebeeb0ee", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d030e2d9-d186-4d37-8ef0-3b4c28875fcd");

            migrationBuilder.AlterColumn<bool>(
                name: "isGpdrRemoveRequest",
                table: "Clubs",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "isBanned",
                table: "Clubs",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "BannedTime",
                table: "Clubs",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "BanPeriod",
                table: "Clubs",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0),
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "53291b98-cc3b-4eb2-9864-cbbb0ab7693d", "f91b5f1e-6ae9-45c6-9708-b324a604a5e4", "Admin", "ADMIN" });
        }
    }
}
