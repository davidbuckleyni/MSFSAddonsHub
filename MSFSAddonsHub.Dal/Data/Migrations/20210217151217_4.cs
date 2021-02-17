using Microsoft.EntityFrameworkCore.Migrations;

namespace MSFSAddonsHub.Dal.Data.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0380166a-c684-4285-8d10-482d2ca664c3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27c3d8e4-4e4e-4bd6-9aeb-51366ad915b8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49942bfc-93d6-4721-bc84-12a2b6f52c4b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f31ec3e-139d-4fe9-9d6f-542f38638269");

            migrationBuilder.AddColumn<string>(
                name: "UserTypeText",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

          
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "234c68de-25ba-469d-915e-5db6acd37827");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6288f246-77c2-47b9-9cf6-8c529d9a29f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9eb4c86-ff77-47cd-bb1d-788d1119cc8c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1ba3ce6-eefd-4b19-a12c-ff776782e48a");

            migrationBuilder.DropColumn(
                name: "UserTypeText",
                table: "AspNetUsers");
 
        }
    }
}
