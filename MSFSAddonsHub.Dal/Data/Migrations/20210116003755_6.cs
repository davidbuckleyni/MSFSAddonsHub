using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MSFSAddonsHub.Dal.Data.Migrations
{
    public partial class _6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "657f0950-9129-4311-bd77-9e1f36005d65");

            migrationBuilder.CreateTable(
                name: "Downloads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddonCategoryId = table.Column<int>(type: "int", nullable: true),
                    ConflictId = table.Column<int>(type: "int", nullable: true),
                    ThumbNail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DownloadLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalDownloads = table.Column<int>(type: "int", nullable: true),
                    DownloadUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    canBeDownloadedByOtherUsers = table.Column<bool>(type: "bit", nullable: true),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isZipFile = table.Column<bool>(type: "bit", nullable: true),
                    isJsonFile = table.Column<bool>(type: "bit", nullable: true),
                    DownloadJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeannatId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    isDisplayHomePage = table.Column<bool>(type: "bit", nullable: true),
                    isFeatured = table.Column<bool>(type: "bit", nullable: true),
                    ThumbNailPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    IPAddressBytes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Downloads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Downloads_Category_AddonCategoryId",
                        column: x => x.AddonCategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4f71df24-4d70-4905-8fb7-d6c470d9e417", "9a0961ce-8ff0-45d0-bda6-03da75cc9469", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_Downloads_AddonCategoryId",
                table: "Downloads",
                column: "AddonCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Downloads");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f71df24-4d70-4905-8fb7-d6c470d9e417");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "657f0950-9129-4311-bd77-9e1f36005d65", "499312f0-0900-4f3e-ba89-92fde1248a14", "Admin", "ADMIN" });
        }
    }
}
