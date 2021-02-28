using Microsoft.EntityFrameworkCore.Migrations;

namespace MSFSAddonsHub.Dal.Data.Migrations
{
    public partial class UpdateUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ab180a-70cf-48b9-9315-4308b385b83f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65f1941d-048a-4b02-ad8e-1757e392aad8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2f9a56d-4e18-4d38-8eab-7a141895b049");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f95d8e54-ab12-406b-973b-ab92d4cab72a");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "20ab180a-70cf-48b9-9315-4308b385b83f", "758c1106-f8e5-4e7e-ba19-17d917d3cdcf", "Admin", "ADMIN" },
                    { "f95d8e54-ab12-406b-973b-ab92d4cab72a", "22d60a74-3fb2-4f89-a086-189c2b22d3b1", "ClubSuperAdmin", "SUPERADMIN" },
                    { "65f1941d-048a-4b02-ad8e-1757e392aad8", "1cc9b255-482b-41f7-ac12-fb154e007405", "ClubMod", "CLUBMOD" },
                    { "c2f9a56d-4e18-4d38-8eab-7a141895b049", "c518b710-4a5e-4866-8d43-0ee601eac5c5", "ClubUser", "CLUBUSER" }
                });
        }
    }
}
