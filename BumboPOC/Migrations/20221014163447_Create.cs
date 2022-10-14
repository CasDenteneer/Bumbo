using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BumboPOC.Migrations
{
    public partial class Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Department = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    BankNumber = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prognosis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmountOfCollies = table.Column<int>(type: "int", nullable: false),
                    AmountOfCustomers = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CassiereDepartment = table.Column<double>(type: "float", nullable: true),
                    FreshDepartment = table.Column<double>(type: "float", nullable: true),
                    StockersDepartment = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prognosis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentsEmployee",
                columns: table => new
                {
                    DepartmentsEmployeeId = table.Column<int>(type: "int", nullable: false),
                    EmployeesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentsEmployee", x => new { x.DepartmentsEmployeeId, x.EmployeesId });
                    table.ForeignKey(
                        name: "FK_DepartmentsEmployee_Departments_DepartmentsEmployeeId",
                        column: x => x.DepartmentsEmployeeId,
                        principalTable: "Departments",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentsEmployee_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlannedShift",
                columns: table => new
                {
                    ShiftId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    PrognosisId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Department = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlannedShift", x => x.ShiftId);
                    table.ForeignKey(
                        name: "FK_PlannedShift_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlannedShift_Prognosis_PrognosisId",
                        column: x => x.PrognosisId,
                        principalTable: "Prognosis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentsEmployee_EmployeesId",
                table: "DepartmentsEmployee",
                column: "EmployeesId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedShift_EmployeeId",
                table: "PlannedShift",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedShift_PrognosisId",
                table: "PlannedShift",
                column: "PrognosisId");

            migrationBuilder.CreateIndex(
                name: "IX_Prognosis_Date",
                table: "Prognosis",
                column: "Date",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentsEmployee");

            migrationBuilder.DropTable(
                name: "PlannedShift");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Prognosis");
        }
    }
}
