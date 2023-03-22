using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SplitProject.DAL.Migrations
{
    /// <inheritdoc />
    public partial class namingChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "UserBalance",
                table: "Users",
                newName: "Balance");

            migrationBuilder.RenameColumn(
                name: "ExpenseTitle",
                table: "Expenses",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "ExpenseDate",
                table: "Expenses",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "ExpenseAmount",
                table: "Expenses",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "BenefiterPercent",
                table: "Benefiters",
                newName: "Percent");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "Balance",
                table: "Users",
                newName: "UserBalance");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Expenses",
                newName: "ExpenseTitle");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Expenses",
                newName: "ExpenseDate");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Expenses",
                newName: "ExpenseAmount");

            migrationBuilder.RenameColumn(
                name: "Percent",
                table: "Benefiters",
                newName: "BenefiterPercent");
        }
    }
}
