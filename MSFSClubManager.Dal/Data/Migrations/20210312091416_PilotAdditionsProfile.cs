using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MSFSClubManager.Dal.Data.Migrations
{
    public partial class PilotAdditionsProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PilotId",
                table: "Friends",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PilotId",
                table: "Flights",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PilotId",
                table: "FileManager",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PilotId",
                table: "ClubLeaderBoards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PilotId",
                table: "Badges",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Pilots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeannatId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AllowFriends = table.Column<bool>(type: "bit", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GamerTag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pilots", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4F75BBA1-1CDF-44A7-84DF-D0C617E5E19D",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0a39751f-aee9-4c3a-8a6f-c9348827b1e1", "AQAAAAEAACcQAAAAENIQ/nCbnocZT8A01AXjwhzSc1bwrF/YJMdCSSuLapUPZIlSr2/5UGSnLESMtScASw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7796F3F2-5600-40A8-99B4-832EE57DC7E1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c8e9e272-19ea-447b-8924-a931d14ada42", "AQAAAAEAACcQAAAAELrarh6wUog6Su+M4P6MzmC+qVzEDnaSYHHTM2qRSSDrHIJsaKa0tiwB8TdiKVDziw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ad7340fd-fa1e-4402-bf2e-5f9042336eab", "AQAAAAEAACcQAAAAEGrGCcWFEcmjtJkE7NWe0g1Sb6bt66DHTirOykyv7U1eQCPm5U0OJSgIUPf1P6ErjA==" });

            migrationBuilder.CreateIndex(
                name: "IX_Friends_PilotId",
                table: "Friends",
                column: "PilotId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_PilotId",
                table: "Flights",
                column: "PilotId");

            migrationBuilder.CreateIndex(
                name: "IX_FileManager_PilotId",
                table: "FileManager",
                column: "PilotId");

            migrationBuilder.CreateIndex(
                name: "IX_ClubLeaderBoards_PilotId",
                table: "ClubLeaderBoards",
                column: "PilotId");

            migrationBuilder.CreateIndex(
                name: "IX_Badges_PilotId",
                table: "Badges",
                column: "PilotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Badges_Pilots_PilotId",
                table: "Badges",
                column: "PilotId",
                principalTable: "Pilots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClubLeaderBoards_Pilots_PilotId",
                table: "ClubLeaderBoards",
                column: "PilotId",
                principalTable: "Pilots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FileManager_Pilots_PilotId",
                table: "FileManager",
                column: "PilotId",
                principalTable: "Pilots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Pilots_PilotId",
                table: "Flights",
                column: "PilotId",
                principalTable: "Pilots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_Pilots_PilotId",
                table: "Friends",
                column: "PilotId",
                principalTable: "Pilots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Badges_Pilots_PilotId",
                table: "Badges");

            migrationBuilder.DropForeignKey(
                name: "FK_ClubLeaderBoards_Pilots_PilotId",
                table: "ClubLeaderBoards");

            migrationBuilder.DropForeignKey(
                name: "FK_FileManager_Pilots_PilotId",
                table: "FileManager");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Pilots_PilotId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Friends_Pilots_PilotId",
                table: "Friends");

            migrationBuilder.DropTable(
                name: "Pilots");

            migrationBuilder.DropIndex(
                name: "IX_Friends_PilotId",
                table: "Friends");

            migrationBuilder.DropIndex(
                name: "IX_Flights_PilotId",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_FileManager_PilotId",
                table: "FileManager");

            migrationBuilder.DropIndex(
                name: "IX_ClubLeaderBoards_PilotId",
                table: "ClubLeaderBoards");

            migrationBuilder.DropIndex(
                name: "IX_Badges_PilotId",
                table: "Badges");

            migrationBuilder.DropColumn(
                name: "PilotId",
                table: "Friends");

            migrationBuilder.DropColumn(
                name: "PilotId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "PilotId",
                table: "FileManager");

            migrationBuilder.DropColumn(
                name: "PilotId",
                table: "ClubLeaderBoards");

            migrationBuilder.DropColumn(
                name: "PilotId",
                table: "Badges");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4F75BBA1-1CDF-44A7-84DF-D0C617E5E19D",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c7924648-e9d0-4245-80df-5f60d1a0a482", "AQAAAAEAACcQAAAAECbkYoh9XdjdFEMqQOM0VZmuppRWLil5VZrJMrYtXf9vpFISOKmUrt2h7fgTFYrbjA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7796F3F2-5600-40A8-99B4-832EE57DC7E1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5ef533c3-7dd9-45a5-bbd0-bdf77a7dc0e7", "AQAAAAEAACcQAAAAEDTO0NwZYO+Gz0kvwCOGUSSkTnsniMoNzStSfnyHkCd/6X5F93T/WAOjUryMk1Kn0w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "efda9b4d-c6e6-44b3-bc05-d4e9b4038a99", "AQAAAAEAACcQAAAAENGeIjv9r1IwI0bXlbCp7d5v42RCNvKDedfD4uIpzzMTvnVz8dFHRKAgIhjdpY//8A==" });
        }
    }
}
