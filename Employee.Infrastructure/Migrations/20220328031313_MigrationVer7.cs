using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Employee.Infrastructure.Migrations
{
    public partial class MigrationVer7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "tbl_employee",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "tbl_employee",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 28, 10, 13, 12, 0, DateTimeKind.Unspecified), "kieu1", new DateTime(2022, 3, 28, 10, 13, 12, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "tbl_employee",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 28, 10, 13, 12, 0, DateTimeKind.Unspecified), "william1", new DateTime(2022, 3, 28, 10, 13, 12, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "tbl_employee",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 28, 10, 13, 12, 0, DateTimeKind.Unspecified), "louis1", new DateTime(2022, 3, 28, 10, 13, 12, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "tbl_employee");

            migrationBuilder.UpdateData(
                table: "tbl_employee",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 23, 4, 25, 41, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 23, 4, 25, 41, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "tbl_employee",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 23, 4, 25, 41, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 23, 4, 25, 41, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "tbl_employee",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 23, 4, 25, 41, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 23, 4, 25, 41, 0, DateTimeKind.Unspecified) });
        }
    }
}
