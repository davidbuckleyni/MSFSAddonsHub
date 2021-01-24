using Microsoft.EntityFrameworkCore.Migrations;

namespace MSFSAddonsHub.Dal.Data.Migrations
{
    public partial class _15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d7c4f65-e2f7-4ba6-9585-3c504b812c5f");

            migrationBuilder.AlterColumn<decimal>(
                name: "LongX",
                table: "Airports",
                type: "decimal(18,9)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "LatY",
                table: "Airports",
                type: "decimal(18,9)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "db33a702-43fe-429b-8064-36e5478a79f2", "b5b8d66e-8719-4635-8214-f6df2cb502f4", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db33a702-43fe-429b-8064-36e5478a79f2");

            migrationBuilder.AlterColumn<decimal>(
                name: "LongX",
                table: "Airports",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,9)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "LatY",
                table: "Airports",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,9)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5d7c4f65-e2f7-4ba6-9585-3c504b812c5f", "75c5dfec-5a13-4505-a6ed-405080382813", "Admin", "ADMIN" });
        }
    }
}
