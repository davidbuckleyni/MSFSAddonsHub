using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MSFSAddonsHub.Dal.Data.Migrations
{
    public partial class _17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1185390e-4c4d-48e3-9b33-6a78ace5b5b7");

            migrationBuilder.AddColumn<string>(
                name: "FileExtensionIcon",
                table: "FileManager",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClubDislikes",
                table: "Clubs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClubLikes",
                table: "Clubs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MembersCount",
                table: "Clubs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Badges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeannatId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BadgeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BadgePoints = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Badges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Badges_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "53291b98-cc3b-4eb2-9864-cbbb0ab7693d", "f91b5f1e-6ae9-45c6-9708-b324a604a5e4", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_Badges_ApplicationUserId",
                table: "Badges",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Badges");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53291b98-cc3b-4eb2-9864-cbbb0ab7693d");

            migrationBuilder.DropColumn(
                name: "FileExtensionIcon",
                table: "FileManager");

            migrationBuilder.DropColumn(
                name: "ClubDislikes",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "ClubLikes",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "MembersCount",
                table: "Clubs");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1185390e-4c4d-48e3-9b33-6a78ace5b5b7", "6795d3c7-2562-4e99-a9d1-ac87214451be", "Admin", "ADMIN" });
        }
    }
}
