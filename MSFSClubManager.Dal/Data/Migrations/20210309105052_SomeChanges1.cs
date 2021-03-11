using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MSFSClubManager.Dal.Data.Migrations
{
    public partial class SomeChanges1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DislikeCount",
                table: "Flights",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DownloadCount",
                table: "Flights",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Flights",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LikedCount",
                table: "Flights",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4F75BBA1-1CDF-44A7-84DF-D0C617E5E19D",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c7924648-e9d0-4245-80df-5f60d1a0a482", "AQAAAAEAACcQAAAAECbkYoh9XdjdFEMqQOM0VZmuppRWLil5VZrJMrYtXf9vpFISOKmUrt2h7fgTFYrbjA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7796F3F2-5600-40A8-99B4-832EE57DC7E1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5ef533c3-7dd9-45a5-bbd0-bdf77a7dc0e7", "AQAAAAEAACcQAAAAEDTO0NwZYO+Gz0kvwCOGUSSkTnsniMoNzStSfnyHkCd/6X5F93T/WAOjUryMk1Kn0w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "efda9b4d-c6e6-44b3-bc05-d4e9b4038a99", "AQAAAAEAACcQAAAAENGeIjv9r1IwI0bXlbCp7d5v42RCNvKDedfD4uIpzzMTvnVz8dFHRKAgIhjdpY//8A==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "DislikeCount",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "DownloadCount",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "LikedCount",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Flights");

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
    }
}
