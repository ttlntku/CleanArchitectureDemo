using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class MigrationVer1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateOfBirth = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Role = table.Column<short>(type: "smallint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_employee", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "tbl_employee",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "PhoneNumber", "Role", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1, new DateTime(2022, 4, 1, 11, 30, 24, 0, DateTimeKind.Unspecified), "KIEU", new DateTime(1999, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "kieungothekieu@gmail.com", "Kieu", "Ngo", "kieu1", "0965117209", (short)201, new DateTime(2022, 4, 1, 11, 30, 24, 0, DateTimeKind.Unspecified), "KIEU" });

            migrationBuilder.InsertData(
                table: "tbl_employee",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "PhoneNumber", "Role", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 2, new DateTime(2022, 4, 1, 11, 30, 24, 0, DateTimeKind.Unspecified), "KIEU", new DateTime(1999, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "williamshakespeare@gmail.com", "William", "Shakespeare", "william1", "0965117209", (short)202, new DateTime(2022, 4, 1, 11, 30, 24, 0, DateTimeKind.Unspecified), "KIEU" });

            migrationBuilder.InsertData(
                table: "tbl_employee",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "PhoneNumber", "Role", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 3, new DateTime(2022, 4, 1, 11, 30, 24, 0, DateTimeKind.Unspecified), "KIEU", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "louisvuitton@gmail.com", "Louis", "Vuitton", "louis1", "0965117209", (short)202, new DateTime(2022, 4, 1, 11, 30, 24, 0, DateTimeKind.Unspecified), "KIEU" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_employee");
        }
    }
}
