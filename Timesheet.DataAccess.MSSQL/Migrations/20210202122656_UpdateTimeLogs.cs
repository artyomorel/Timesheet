using Microsoft.EntityFrameworkCore.Migrations;

namespace Timesheet.DataAccess.MSSQL.Migrations
{
    public partial class UpdateTimeLogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeLogs_Employees_EmployeeId",
                table: "TimeLogs");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "TimeLogs");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "TimeLogs",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeLogs_Employees_EmployeeId",
                table: "TimeLogs",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeLogs_Employees_EmployeeId",
                table: "TimeLogs");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "TimeLogs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "TimeLogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeLogs_Employees_EmployeeId",
                table: "TimeLogs",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
