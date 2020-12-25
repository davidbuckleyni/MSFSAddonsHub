using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MSFSAddonsHub.Dal.Data.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Major",
                table: "DownloadManager");

            migrationBuilder.RenameColumn(
                name: "Minior",
                table: "DownloadManager",
                newName: "RowVersion");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "DownloadManager",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "DownloadManager",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "DownloadManager",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "DownloadManager",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "AddOnDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "AddOnDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "AddOnDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "AddOnDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "DownloadManager");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "DownloadManager");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "DownloadManager");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "DownloadManager");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AddOnDetails");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "AddOnDetails");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "AddOnDetails");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "AddOnDetails");

            migrationBuilder.RenameColumn(
                name: "RowVersion",
                table: "DownloadManager",
                newName: "Minior");

            migrationBuilder.AddColumn<int>(
                name: "Major",
                table: "DownloadManager",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
