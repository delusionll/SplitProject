using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SplitProject.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CreateABCTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Benefiters_Expenses_ExpenseId",
                table: "Benefiters");

            migrationBuilder.DropForeignKey(
                name: "FK_Benefiters_Users_UserId",
                table: "Benefiters");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Users_UserId",
                table: "Expenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expenses",
                table: "Expenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Benefiters",
                table: "Benefiters");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ExpenseId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "BenefiterId",
                table: "Benefiters");

            migrationBuilder.AlterColumn<decimal>(
                name: "UserBalance",
                table: "Users",
                type: "decimal(13,2)",
                precision: 13,
                scale: 2,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Expenses",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "ExpenseAmount",
                table: "Expenses",
                type: "decimal(13,2)",
                precision: 13,
                scale: 2,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Expenses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Benefiters",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "ExpenseId",
                table: "Benefiters",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Benefiters",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expenses",
                table: "Expenses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Benefiters",
                table: "Benefiters",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Benefiters_Expenses_ExpenseId",
                table: "Benefiters",
                column: "ExpenseId",
                principalTable: "Expenses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Benefiters_Users_UserId",
                table: "Benefiters",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Users_UserId",
                table: "Expenses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Benefiters_Expenses_ExpenseId",
                table: "Benefiters");

            migrationBuilder.DropForeignKey(
                name: "FK_Benefiters_Users_UserId",
                table: "Benefiters");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Users_UserId",
                table: "Expenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expenses",
                table: "Expenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Benefiters",
                table: "Benefiters");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Benefiters");

            migrationBuilder.AlterColumn<double>(
                name: "UserBalance",
                table: "Users",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(13,2)",
                oldPrecision: 13,
                oldScale: 2);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Expenses",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<double>(
                name: "ExpenseAmount",
                table: "Expenses",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(13,2)",
                oldPrecision: 13,
                oldScale: 2);

            migrationBuilder.AddColumn<int>(
                name: "ExpenseId",
                table: "Expenses",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Benefiters",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "ExpenseId",
                table: "Benefiters",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<int>(
                name: "BenefiterId",
                table: "Benefiters",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expenses",
                table: "Expenses",
                column: "ExpenseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Benefiters",
                table: "Benefiters",
                column: "BenefiterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Benefiters_Expenses_ExpenseId",
                table: "Benefiters",
                column: "ExpenseId",
                principalTable: "Expenses",
                principalColumn: "ExpenseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Benefiters_Users_UserId",
                table: "Benefiters",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Users_UserId",
                table: "Expenses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
