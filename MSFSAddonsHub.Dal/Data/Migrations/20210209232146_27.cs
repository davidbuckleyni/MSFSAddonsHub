using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MSFSAddonsHub.Dal.Data.Migrations
{
    public partial class _27 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5368d98-17df-4c18-9b5f-67fb6b5b44ed");

            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeannatId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ClubId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FriendIdId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    hasExcepted = table.Column<bool>(type: "bit", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    RequestedIp = table.Column<int>(type: "int", nullable: true),
                    isBlocked = table.Column<bool>(type: "bit", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Friends_AspNetUsers_FriendIdId",
                        column: x => x.FriendIdId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FriendsRequest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeannatId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ClubId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreindRequestedIdId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FriendIdId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RequestedIp = table.Column<int>(type: "int", nullable: true),
                    hasAccepted = table.Column<bool>(type: "bit", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    isBlocked = table.Column<bool>(type: "bit", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendsRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FriendsRequest_AspNetUsers_FreindRequestedIdId",
                        column: x => x.FreindRequestedIdId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FriendsRequest_AspNetUsers_FriendIdId",
                        column: x => x.FriendIdId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "947cc9b8-5773-484a-ad18-779711f56c11", "c617bb3c-516f-49b4-b44d-c8d306c3d58d", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_Friends_FriendIdId",
                table: "Friends",
                column: "FriendIdId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendsRequest_FreindRequestedIdId",
                table: "FriendsRequest",
                column: "FreindRequestedIdId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendsRequest_FriendIdId",
                table: "FriendsRequest",
                column: "FriendIdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friends");

            migrationBuilder.DropTable(
                name: "FriendsRequest");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "947cc9b8-5773-484a-ad18-779711f56c11");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e5368d98-17df-4c18-9b5f-67fb6b5b44ed", "e40bb46b-1429-4828-bef4-51f773027a6a", "Admin", "ADMIN" });
        }
    }
}
