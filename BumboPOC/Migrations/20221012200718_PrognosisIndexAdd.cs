using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BumboPOC.Migrations
{
    public partial class PrognosisIndexAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "StockersDepartment",
                table: "Prognosis",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "FreshDepartment",
                table: "Prognosis",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "CassiereDepartment",
                table: "Prognosis",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.CreateIndex(
                name: "IX_Prognosis_Date",
                table: "Prognosis",
                column: "Date",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Prognosis_Date",
                table: "Prognosis");

            migrationBuilder.AlterColumn<double>(
                name: "StockersDepartment",
                table: "Prognosis",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "FreshDepartment",
                table: "Prognosis",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "CassiereDepartment",
                table: "Prognosis",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);
        }
    }
}
