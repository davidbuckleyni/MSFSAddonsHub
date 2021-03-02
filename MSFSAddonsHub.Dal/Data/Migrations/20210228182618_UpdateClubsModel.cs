using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MSFSAddonsHub.Dal.Data.Migrations
{
    public partial class UpdateClubsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2924519a-7024-417f-a8e1-335dca7dba63");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f6e4213-d513-47ae-8e02-dcdeaa4e22c9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40ff2868-3264-4195-82c4-68bddcc5b036");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b1b831c-61ac-46b9-88f5-089a11f1e46e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4F75BBA1-1CDF-44A7-84DF-D0C617E5E19D");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7796F3F2-5600-40A8-99B4-832EE57DC7E1");

            migrationBuilder.AddColumn<int>(
                name: "ClubBadgesId",
                table: "ClubMembers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClubInvitesId",
                table: "ClubMembers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClubLeaderBoardsId",
                table: "ClubMembers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ClubLeaderBoards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeannatId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Postion = table.Column<int>(type: "int", nullable: true),
                    Points = table.Column<int>(type: "int", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubLeaderBoards", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "77d20ebb-02c4-4bcf-aea4-b59c0bd5104f", "d971408b-66e4-4d95-81dd-9d0f390c969f", "Admin", "ADMIN" },
                    { "42334e14-fb4a-4613-8e0f-9e46abd8e41c", "7e4476e7-a122-4cde-b296-88b6666c839c", "ClubSuperAdmin", "SUPERADMIN" },
                    { "62559f2a-959a-4ddb-b50f-0c7700d38058", "1a0620e2-5de6-4f94-ab02-bc737b5efa6a", "ClubMod", "CLUBMOD" },
                    { "37a8a81f-eed1-4d92-b3f5-872880d6d7fb", "5f2766db-9c2b-4282-8f33-23117deee43d", "ClubUser", "CLUBUSER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "c2f9a56d-4e18-4d38-8eab-7a141895b049", "4F75BBA1-1CDF-44A7-84DF-D0C617E5E19D" },
                    { "65f1941d-048a-4b02-ad8e-1757e392aad8", "7796F3F2-5600-40A8-99B4-832EE57DC7E1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClubMembers_ClubBadgesId",
                table: "ClubMembers",
                column: "ClubBadgesId");

            migrationBuilder.CreateIndex(
                name: "IX_ClubMembers_ClubInvitesId",
                table: "ClubMembers",
                column: "ClubInvitesId");

            migrationBuilder.CreateIndex(
                name: "IX_ClubMembers_ClubLeaderBoardsId",
                table: "ClubMembers",
                column: "ClubLeaderBoardsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClubMembers_Badges_ClubBadgesId",
                table: "ClubMembers",
                column: "ClubBadgesId",
                principalTable: "Badges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClubMembers_ClubInvites_ClubInvitesId",
                table: "ClubMembers",
                column: "ClubInvitesId",
                principalTable: "ClubInvites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClubMembers_ClubLeaderBoards_ClubLeaderBoardsId",
                table: "ClubMembers",
                column: "ClubLeaderBoardsId",
                principalTable: "ClubLeaderBoards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClubMembers_Badges_ClubBadgesId",
                table: "ClubMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_ClubMembers_ClubInvites_ClubInvitesId",
                table: "ClubMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_ClubMembers_ClubLeaderBoards_ClubLeaderBoardsId",
                table: "ClubMembers");

            migrationBuilder.DropTable(
                name: "ClubLeaderBoards");

            migrationBuilder.DropIndex(
                name: "IX_ClubMembers_ClubBadgesId",
                table: "ClubMembers");

            migrationBuilder.DropIndex(
                name: "IX_ClubMembers_ClubInvitesId",
                table: "ClubMembers");

            migrationBuilder.DropIndex(
                name: "IX_ClubMembers_ClubLeaderBoardsId",
                table: "ClubMembers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37a8a81f-eed1-4d92-b3f5-872880d6d7fb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42334e14-fb4a-4613-8e0f-9e46abd8e41c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62559f2a-959a-4ddb-b50f-0c7700d38058");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77d20ebb-02c4-4bcf-aea4-b59c0bd5104f");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c2f9a56d-4e18-4d38-8eab-7a141895b049", "4F75BBA1-1CDF-44A7-84DF-D0C617E5E19D" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "65f1941d-048a-4b02-ad8e-1757e392aad8", "7796F3F2-5600-40A8-99B4-832EE57DC7E1" });

            migrationBuilder.DropColumn(
                name: "ClubBadgesId",
                table: "ClubMembers");

            migrationBuilder.DropColumn(
                name: "ClubInvitesId",
                table: "ClubMembers");

            migrationBuilder.DropColumn(
                name: "ClubLeaderBoardsId",
                table: "ClubMembers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4b1b831c-61ac-46b9-88f5-089a11f1e46e", "1452e136-cadb-418d-99a6-b613814b941e", "Admin", "ADMIN" },
                    { "40ff2868-3264-4195-82c4-68bddcc5b036", "db6de142-a6b1-4dcb-b699-e994ddf69252", "ClubSuperAdmin", "SUPERADMIN" },
                    { "2924519a-7024-417f-a8e1-335dca7dba63", "a0d8b8ca-1266-4b8b-8245-e15607db45f7", "ClubMod", "CLUBMOD" },
                    { "3f6e4213-d513-47ae-8e02-dcdeaa4e22c9", "e6389086-1476-4076-9f28-52eea3af84f8", "ClubUser", "CLUBUSER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AvatarImage", "ClubId", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "GamerTag", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TennantId", "TwoFactorEnabled", "UserName", "UserType", "UserTypeText", "isOnline" },
                values: new object[,]
                {
                    { "7796F3F2-5600-40A8-99B4-832EE57DC7E1", 0, null, null, "74a78786-7be3-458c-b7e8-e34c951a41dd", "test1@msfsaddonshub.com", true, "Martha", null, "Jones", false, null, "test1@msfsaddonshub.com", "test1@msfsaddonshub.com", "AQAAAAEAACcQAAAAEPLyVSnTB1sUzsy0aJgqkgACoJd9M4HxEz8Y5y1MtM5lIJNhyr/K8nVqqKlhCDas/w==", "XXXXXXXXXXXXX", true, "00000000-0000-0000-0000-000000000000", null, false, "test1@msfsaddonshub.com", 199, null, null },
                    { "4F75BBA1-1CDF-44A7-84DF-D0C617E5E19D", 0, null, null, "c911e855-7c66-4394-9f9a-d37e7da2eb16", "test2@msfsaddonshub.com", true, "The", null, "Dr", false, null, "test2@msfsaddonshub.com", "test2@msfsaddonshub.com", "AQAAAAEAACcQAAAAEJsw4kPpMKrv5ZPJoc2rx5z9R7yFQla352HGszeV4B+nbq1oltd8l+fcthdZUnfzxg==", "XXXXXXXXXXXXX", true, "00000000-0000-0000-0000-000000000000", null, false, "test2@msfsaddonshub.com", 199, null, null }
                });
        }
    }
}
