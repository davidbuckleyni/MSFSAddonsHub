using Microsoft.EntityFrameworkCore.Migrations;

namespace MSFSClubManager.Dal.Data.Migrations
{
    public partial class SeedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d4cc254-2c49-4964-8b17-248d5e03ba0e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85ea9884-b566-44e8-8e58-a55d543de907");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b955efdb-54ef-4cf8-8e3f-f33a93e9238c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fedd6466-d656-4524-a1e4-6cad27411147");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c2f9a56d-4e18-4d38-8eab-7a141895b049", "4F75BBA1-1CDF-44A7-84DF-D0C617E5E19D" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "65f1941d-048a-4b02-ad8e-1757e392aad8", "7796F3F2-5600-40A8-99B4-832EE57DC7E1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4F75BBA1-1CDF-44A7-84DF-D0C617E5E19D",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e4cec1d8-1adb-4b54-9bd5-59a211845f4b", "AQAAAAEAACcQAAAAEJGcO6mkq6UgRpdAcn42MBIAd4wk5YXmGU39p4z13kkN0PSRdAQNCFsBmLRErUMhSg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7796F3F2-5600-40A8-99B4-832EE57DC7E1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a93851ac-2355-4ac2-93b6-8ee12401ce3a", "AQAAAAEAACcQAAAAEBLlupNuaYj6v/DNsfy3PfvHXXhTljROcyVYjZn1OK9/vFgH9kVHtgqFpAf7Bkwohg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "edb517a4-2766-48a7-be32-26d3525a9e3a", "AQAAAAEAACcQAAAAEH+noGuJUAHucQehakXBHU86CQJC0eotdXBgjDcemi++kYoQG9Bu7ScsyhqQvFCftQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "85ea9884-b566-44e8-8e58-a55d543de907", "137be0e1-b2f6-44e3-98dc-e7fc73b843d6", "Admin", "ADMIN" },
                    { "b955efdb-54ef-4cf8-8e3f-f33a93e9238c", "60367467-b3f0-47dc-ad4f-65a90c71f8b8", "ClubSuperAdmin", "SUPERADMIN" },
                    { "4d4cc254-2c49-4964-8b17-248d5e03ba0e", "9d193126-ad7e-44db-b961-1eb2bd886d02", "ClubMod", "CLUBMOD" },
                    { "fedd6466-d656-4524-a1e4-6cad27411147", "77b45f49-045d-41c7-99ed-5a2ed7764f79", "ClubUser", "CLUBUSER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "c2f9a56d-4e18-4d38-8eab-7a141895b049", "4F75BBA1-1CDF-44A7-84DF-D0C617E5E19D" },
                    { "65f1941d-048a-4b02-ad8e-1757e392aad8", "7796F3F2-5600-40A8-99B4-832EE57DC7E1" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4F75BBA1-1CDF-44A7-84DF-D0C617E5E19D",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "de595f72-fa6f-474c-9515-6c9bb1c7818f", "AQAAAAEAACcQAAAAEEMJzkVvfa0DvGh6XlIupgXekA8LJlWPXrBO7aSYXOrB6UR4wOVc00XP4GgbO9Heeg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7796F3F2-5600-40A8-99B4-832EE57DC7E1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c4c8b5f7-67d5-46dc-a26f-658003e53a7f", "AQAAAAEAACcQAAAAEEhZWX6UKNoOrZ/v5wVFz9X2R8Z6nhIoCCUL4LRlF10qSRs1ZcwMTN8j3Xn+/cRx1A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a7012044-670c-49bf-a83b-33b57c965a0e", "AQAAAAEAACcQAAAAEEFDnNcjrRNZF8oK5mzZajqtyIsuO19p5PNYIoH5vS1d8S5/NN0Wf8A9Zo8NSmKHLw==" });
        }
    }
}
