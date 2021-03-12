using Microsoft.EntityFrameworkCore.Migrations;

namespace MSFSClubManager.Dal.Data.Migrations
{
    public partial class AddAvatarImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AvatarImage",
                table: "Clubs",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvatarImage",
                table: "Clubs");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4F75BBA1-1CDF-44A7-84DF-D0C617E5E19D",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "266a48d2-9ae6-4af5-b3f0-735d5951e06f", "AQAAAAEAACcQAAAAEEEM5+2vBOD/JfKoZOTBUh6yIxpm0Ro+E/xNVGMDpGvyGWCWtIRZrfjUwhgSjNO7HQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7796F3F2-5600-40A8-99B4-832EE57DC7E1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8986b2b3-44b7-4d91-9222-ff67e1c5fd28", "AQAAAAEAACcQAAAAELbTE4CRl4EHPYOFYi1oephGCHsHuj55VV2KYnAIzJouQsJHGbJwjjfqy2hTReteSg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d2da1944-03a2-4c09-8976-c8b3f26fa00c", "AQAAAAEAACcQAAAAEKOrcomAm0l+tugP/bIR7XnGck7SBq3hUfKgnMG+8uOs7B/2E7EnSPLNTDq5n3maCQ==" });
        }
    }
}
