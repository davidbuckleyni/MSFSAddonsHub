using Microsoft.EntityFrameworkCore.Migrations;

namespace MSFSAddonsHub.Dal.Data.Migrations
{
    public partial class _13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Clubs_ClubId",
                table: "Flights");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9fcd2d4-2b0c-4482-b85b-6092d3ac1072");

            migrationBuilder.AlterColumn<int>(
                name: "Version",
                table: "Flights",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClubId",
                table: "Flights",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "49c78ab6-eaac-4292-afc3-63ff7005695b", "63aa5755-63b5-41b4-9796-04551a8a46fd", "Admin", "ADMIN" });

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Clubs_ClubId",
                table: "Flights",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Clubs_ClubId",
                table: "Flights");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49c78ab6-eaac-4292-afc3-63ff7005695b");

            migrationBuilder.AlterColumn<int>(
                name: "Version",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClubId",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f9fcd2d4-2b0c-4482-b85b-6092d3ac1072", "956f56b5-45db-427a-acd5-819852bbe7c3", "Admin", "ADMIN" });

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Clubs_ClubId",
                table: "Flights",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
