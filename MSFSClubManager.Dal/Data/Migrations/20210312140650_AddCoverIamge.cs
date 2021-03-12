using Microsoft.EntityFrameworkCore.Migrations;

namespace MSFSClubManager.Dal.Data.Migrations
{
    public partial class AddCoverIamge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoverImage",
                table: "Clubs",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverImage",
                table: "Clubs");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4F75BBA1-1CDF-44A7-84DF-D0C617E5E19D",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0a39751f-aee9-4c3a-8a6f-c9348827b1e1", "AQAAAAEAACcQAAAAENIQ/nCbnocZT8A01AXjwhzSc1bwrF/YJMdCSSuLapUPZIlSr2/5UGSnLESMtScASw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7796F3F2-5600-40A8-99B4-832EE57DC7E1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c8e9e272-19ea-447b-8924-a931d14ada42", "AQAAAAEAACcQAAAAELrarh6wUog6Su+M4P6MzmC+qVzEDnaSYHHTM2qRSSDrHIJsaKa0tiwB8TdiKVDziw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ad7340fd-fa1e-4402-bf2e-5f9042336eab", "AQAAAAEAACcQAAAAEGrGCcWFEcmjtJkE7NWe0g1Sb6bt66DHTirOykyv7U1eQCPm5U0OJSgIUPf1P6ErjA==" });
        }
    }
}
