using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BumboPOC.Migrations
{
    public partial class EmployeeFirstAdds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                table: "Employees");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Employees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "BankNumber",
                table: "Employees",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Employees",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Department = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => new { x.EmployeeId, x.Department });
                });

            migrationBuilder.CreateTable(
                name: "DepartmentsEmployee",
                columns: table => new
                {
                    EmployeesId = table.Column<int>(type: "int", nullable: false),
                    DepartmentsEmployeeId = table.Column<int>(type: "int", nullable: false),
                    DepartmentsDepartment = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentsEmployee", x => new { x.EmployeesId, x.DepartmentsEmployeeId, x.DepartmentsDepartment });
                    table.ForeignKey(
                        name: "FK_DepartmentsEmployee_Departments_DepartmentsEmployeeId_DepartmentsDepartment",
                        columns: x => new { x.DepartmentsEmployeeId, x.DepartmentsDepartment },
                        principalTable: "Departments",
                        principalColumns: new[] { "EmployeeId", "Department" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentsEmployee_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentsEmployee_DepartmentsEmployeeId_DepartmentsDepartment",
                table: "DepartmentsEmployee",
                columns: new[] { "DepartmentsEmployeeId", "DepartmentsDepartment" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentsEmployee");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "BankNumber",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
