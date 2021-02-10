using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MSFSAddonsHub.Dal.Data.Migrations
{
    public partial class _24 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b12316a-5ebf-4113-bc69-da0013cd96ba");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FlightDate",
                table: "Flights",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "EndTime",
                table: "Flights",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Flights",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "StartTime",
                table: "Flights",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TimeInFluent",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TimeZone",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TimeinMins",
                table: "Flights",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ClubsDownloads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeannatId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ClubId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlightId = table.Column<int>(type: "int", nullable: true),
                    FileId = table.Column<int>(type: "int", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubsDownloads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClubsDownloads_FileManager_FileId",
                        column: x => x.FileId,
                        principalTable: "FileManager",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "39c2fdf9-9a85-40f8-884b-49791cb0fa16", "2c1b60ea-129f-4d06-b2f9-1d518aa70f7f", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_ClubsDownloads_FileId",
                table: "ClubsDownloads",
                column: "FileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClubsDownloads");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39c2fdf9-9a85-40f8-884b-49791cb0fa16");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "TimeInFluent",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "TimeZone",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "TimeinMins",
                table: "Flights");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "FlightDate",
                table: "Flights",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6b12316a-5ebf-4113-bc69-da0013cd96ba", "86257dcd-8522-45f7-b7ef-f2db396271f0", "Admin", "ADMIN" });
        }
    }
}
