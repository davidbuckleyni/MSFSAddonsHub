using Microsoft.EntityFrameworkCore.Migrations;

namespace MSFSAddonsHub.Dal.Data.Migrations
{
    public partial class _30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Clubs_ClubId1",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ClubId1",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "928d5219-7f06-43d6-8f32-aa0077d28fd4");

            migrationBuilder.DropColumn(
                name: "ClubId1",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "ApplicationUserClub",
                columns: table => new
                {
                    ClubsId = table.Column<int>(type: "int", nullable: false),
                    MembersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserClub", x => new { x.ClubsId, x.MembersId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserClub_AspNetUsers_MembersId",
                        column: x => x.MembersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserClub_Clubs_ClubsId",
                        column: x => x.ClubsId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f2ede003-aaeb-4d10-907a-60bd9afae4ab", "cc84ca1d-8d89-4920-b91c-7b23ec27c77e", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserClub_MembersId",
                table: "ApplicationUserClub",
                column: "MembersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserClub");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2ede003-aaeb-4d10-907a-60bd9afae4ab");

            migrationBuilder.AddColumn<int>(
                name: "ClubId1",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "928d5219-7f06-43d6-8f32-aa0077d28fd4", "91bab6ba-a240-4dca-ac54-1adcf3f7f69a", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ClubId1",
                table: "AspNetUsers",
                column: "ClubId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Clubs_ClubId1",
                table: "AspNetUsers",
                column: "ClubId1",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
