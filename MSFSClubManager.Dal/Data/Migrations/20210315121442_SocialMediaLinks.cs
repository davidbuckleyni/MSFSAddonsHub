using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MSFSClubManager.Dal.Data.Migrations
{
    public partial class SocialMediaLinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SocialMediaLinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeannatId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClubId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMediaLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialMediaLinks_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4F75BBA1-1CDF-44A7-84DF-D0C617E5E19D",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "663f8996-fbd4-4fc9-9d43-ec8011749d57", "AQAAAAEAACcQAAAAEIcxG2peQFvbIxy2XGTyNrfJJ8oe081OmOkXqvx9oIfuw2ZVsHRuO36okxUGo34SCQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7796F3F2-5600-40A8-99B4-832EE57DC7E1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9e05c78d-160b-468c-920d-347c4bbe2c61", "AQAAAAEAACcQAAAAEGQAmsDZofcFbbJ/Usqs//OLE0cAfzF8I/idzkjrdTD/LgXIl3BiZDkPcJk1wf2I+g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fac8355e-6818-4808-8e35-851d8f0dbf6a", "AQAAAAEAACcQAAAAEIV/Njutlnip4FW7ndj4Jn679F5bvr1TnpVH9wuNvFYLe/IO7LcdNNYR1xOarqTbvg==" });

            migrationBuilder.CreateIndex(
                name: "IX_SocialMediaLinks_ClubId",
                table: "SocialMediaLinks",
                column: "ClubId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SocialMediaLinks");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4F75BBA1-1CDF-44A7-84DF-D0C617E5E19D",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fe853564-1c86-4819-bda3-3d0d169c33f3", "AQAAAAEAACcQAAAAECgO9Oht4L3v5DJSWzQC6JzdbkOW+Cyz8QXHP00CdFb2Rf3FHAV3TDTtjrVPGSo7zg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7796F3F2-5600-40A8-99B4-832EE57DC7E1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "49326f82-670f-4c8c-8259-3a5907990992", "AQAAAAEAACcQAAAAEH+IsRII+nZvoiv5HHZ0FMmGhpnTy36cfOdznhJkPmxX1V8dBb3QEF4FS+zg7zexkQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "96b0f3b5-ca61-40bb-9802-e8bed1747f7a", "AQAAAAEAACcQAAAAEO43z01Dtf4YNWWZsJds7lKEINoLIiHVTojur4wXydZb+MAxvN196YIln4HotwunKg==" });
        }
    }
}
