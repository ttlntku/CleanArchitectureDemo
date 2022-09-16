using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class MigrationVer2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_factory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FactoryName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FactoryAddress = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_factory", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EmployeeEntityFactoryEntity",
                columns: table => new
                {
                    EmployeesId = table.Column<int>(type: "int", nullable: false),
                    FactoriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeEntityFactoryEntity", x => new { x.EmployeesId, x.FactoriesId });
                    table.ForeignKey(
                        name: "FK_EmployeeEntityFactoryEntity_tbl_employee_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "tbl_employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeEntityFactoryEntity_tbl_factory_FactoriesId",
                        column: x => x.FactoriesId,
                        principalTable: "tbl_factory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "tbl_employee",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 14, 2, 37, 31, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 2, 37, 31, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "tbl_employee",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 14, 2, 37, 31, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 2, 37, 31, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "tbl_employee",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 14, 2, 37, 31, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 2, 37, 31, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "tbl_factory",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "FactoryAddress", "FactoryName", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 9, 14, 2, 37, 31, 0, DateTimeKind.Unspecified), "KIEU", "Next Eight", "Sam Sung", new DateTime(2022, 9, 14, 2, 37, 31, 0, DateTimeKind.Unspecified), "KIEU" },
                    { 2, new DateTime(2022, 9, 14, 2, 37, 31, 0, DateTimeKind.Unspecified), "KIEU", "America Dinh", "Apple", new DateTime(2022, 9, 14, 2, 37, 31, 0, DateTimeKind.Unspecified), "KIEU" },
                    { 3, new DateTime(2022, 9, 14, 2, 37, 31, 0, DateTimeKind.Unspecified), "KIEU", "Park Ninh", "Amazon", new DateTime(2022, 9, 14, 2, 37, 31, 0, DateTimeKind.Unspecified), "KIEU" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEntityFactoryEntity_FactoriesId",
                table: "EmployeeEntityFactoryEntity",
                column: "FactoriesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeEntityFactoryEntity");

            migrationBuilder.DropTable(
                name: "tbl_factory");

            migrationBuilder.UpdateData(
                table: "tbl_employee",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 4, 1, 11, 30, 24, 0, DateTimeKind.Unspecified), new DateTime(2022, 4, 1, 11, 30, 24, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "tbl_employee",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 4, 1, 11, 30, 24, 0, DateTimeKind.Unspecified), new DateTime(2022, 4, 1, 11, 30, 24, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "tbl_employee",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 4, 1, 11, 30, 24, 0, DateTimeKind.Unspecified), new DateTime(2022, 4, 1, 11, 30, 24, 0, DateTimeKind.Unspecified) });
        }
    }
}
