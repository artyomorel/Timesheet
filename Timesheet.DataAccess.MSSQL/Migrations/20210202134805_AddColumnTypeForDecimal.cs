using Microsoft.EntityFrameworkCore.Migrations;

namespace Timesheet.DataAccess.MSSQL.Migrations
{
    public partial class AddColumnTypeForDecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                table: "Employees",
                type: "decimal",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Bonus",
                table: "Employees",
                type: "decimal",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,2)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                table: "Employees",
                type: "decimal(8,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal");

            migrationBuilder.AlterColumn<decimal>(
                name: "Bonus",
                table: "Employees",
                type: "decimal(8,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal",
                oldNullable: true);
        }
    }
}
