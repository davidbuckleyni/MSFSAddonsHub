using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MSFSAddonsHub.Dal.Data.Migrations
{
    public partial class _7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Downloads");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f71df24-4d70-4905-8fb7-d6c470d9e417");

            migrationBuilder.CreateTable(
                name: "FileFolders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConflictId = table.Column<int>(type: "int", nullable: true),
                    ThumbNail = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_FileFolders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileManager",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoldersId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_FileManager", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileManager_FileFolders_FoldersId",
                        column: x => x.FoldersId,
                        principalTable: "FileFolders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0fc348a9-ee62-4885-8ece-63d7dda0af68", "aa644244-2849-4e40-b20e-1e363d55b9e1", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_FileManager_FoldersId",
                table: "FileManager",
                column: "FoldersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileManager");

            migrationBuilder.DropTable(
                name: "FileFolders");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0fc348a9-ee62-4885-8ece-63d7dda0af68");

            migrationBuilder.CreateTable(
                name: "Downloads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddonCategoryId = table.Column<int>(type: "int", nullable: true),
                    ConflictId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DownloadJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DownloadLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DownloadUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IPAddressBytes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeannatId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ThumbNail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThumbNailPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalDownloads = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    canBeDownloadedByOtherUsers = table.Column<bool>(type: "bit", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    isDisplayHomePage = table.Column<bool>(type: "bit", nullable: true),
                    isFeatured = table.Column<bool>(type: "bit", nullable: true),
                    isJsonFile = table.Column<bool>(type: "bit", nullable: true),
                    isZipFile = table.Column<bool>(type: "bit", nullable: true)
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
    }
}
