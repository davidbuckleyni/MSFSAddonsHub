using Microsoft.EntityFrameworkCore.Migrations;

namespace MSFSClubManager.Dal.Data.Migrations
{
    public partial class ModType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AddonType",
                table: "Mods",
                newName: "ModType");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4F75BBA1-1CDF-44A7-84DF-D0C617E5E19D",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3ca4c8bf-5703-4fd1-8c8f-9651320a46d4", "AQAAAAEAACcQAAAAEJoF1ON9KzcxzmZpIg1GAgwvceyFLLkrK5RjPHqc+bAFTPqaODtWZunvgO74xlxhZg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7796F3F2-5600-40A8-99B4-832EE57DC7E1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f9e9346b-b5a1-442e-b29f-0c98d70983fa", "AQAAAAEAACcQAAAAENx8pZMiJ+yz0BwMTrzOX6MNWrMAV+XUbh1iUUUAZfL5KRPYOf61evquGIetmFPObw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3a7b0c2d-471f-4bbb-95e1-24d85593ee45", "AQAAAAEAACcQAAAAEENl13k6I321b8OLWLs+N/SLCf/mg4g9Wu8IF0ZVoy0nsmuQx4E1kTq/3+MiT4EA6g==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModType",
                table: "Mods",
                newName: "AddonType");

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
    }
}
