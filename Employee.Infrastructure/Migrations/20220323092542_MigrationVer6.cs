using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Employee.Infrastructure.Migrations
{
    public partial class MigrationVer6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "tbl_employee",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "tbl_employee",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "tbl_employee",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "tbl_employee",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "tbl_employee",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DateOfBirth", "Email", "FirstName", "LastName", "PhoneNumber", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1, new DateTime(2022, 3, 23, 4, 25, 41, 0, DateTimeKind.Unspecified), "KIEU", new DateTime(1999, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "kieungothekieu@gmail.com", "Kieu", "Ngo", "0965117209", new DateTime(2022, 3, 23, 4, 25, 41, 0, DateTimeKind.Unspecified), "KIEU" });

            migrationBuilder.InsertData(
                table: "tbl_employee",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DateOfBirth", "Email", "FirstName", "LastName", "PhoneNumber", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 2, new DateTime(2022, 3, 23, 4, 25, 41, 0, DateTimeKind.Unspecified), "KIEU", new DateTime(1999, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "williamshakespeare@gmail.com", "William", "Shakespeare", "0965117209", new DateTime(2022, 3, 23, 4, 25, 41, 0, DateTimeKind.Unspecified), "KIEU" });

            migrationBuilder.InsertData(
                table: "tbl_employee",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DateOfBirth", "Email", "FirstName", "LastName", "PhoneNumber", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 3, new DateTime(2022, 3, 23, 4, 25, 41, 0, DateTimeKind.Unspecified), "KIEU", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "louisvuitton@gmail.com", "Louis", "Vuitton", "0965117209", new DateTime(2022, 3, 23, 4, 25, 41, 0, DateTimeKind.Unspecified), "KIEU" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tbl_employee",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tbl_employee",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tbl_employee",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "tbl_employee");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "tbl_employee");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "tbl_employee");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "tbl_employee");
        }
    }
}
