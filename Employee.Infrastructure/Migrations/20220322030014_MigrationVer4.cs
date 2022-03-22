using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Employee.Infrastructure.Migrations
{
    public partial class MigrationVer4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tbl_employee",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 1, new DateTime(1999, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "kieungothekieu@gmail.com", "Kieu", "Ngo", "0965117209" });

            migrationBuilder.InsertData(
                table: "tbl_employee",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 2, new DateTime(1999, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "williamshakespeare@gmail.com", "William", "Shakespeare", "0965117209" });

            migrationBuilder.InsertData(
                table: "tbl_employee",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 3, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "louisvuitton@gmail.com", "Louis", "Vuitton", "0965117209" });
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
        }
    }
}
