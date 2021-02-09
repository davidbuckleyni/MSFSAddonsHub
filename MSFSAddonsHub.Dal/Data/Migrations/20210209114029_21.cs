using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MSFSAddonsHub.Dal.Data.Migrations
{
    public partial class _21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07e6ad56-e286-4112-870b-e4321596dfaa");

            migrationBuilder.AddColumn<Guid>(
                name: "ClubId",
                table: "Clubs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "146693de-1cd2-4738-9700-79fff76266e2", "876fe1a6-b47d-4515-858a-e636f4a6713f", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "146693de-1cd2-4738-9700-79fff76266e2");

            migrationBuilder.DropColumn(
                name: "ClubId",
                table: "Clubs");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "07e6ad56-e286-4112-870b-e4321596dfaa", "ab5c87c2-7a1a-4e50-8f13-0279478aa58b", "Admin", "ADMIN" });
        }
    }
}
