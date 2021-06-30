using Microsoft.EntityFrameworkCore.Migrations;

namespace FinanceTracker.API.Migrations
{
    public partial class RemoveExpenseFromTransactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Expenses_ExpenseId",
                table: "Transactions");

            migrationBuilder.AlterColumn<int>(
                name: "ExpenseId",
                table: "Transactions",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Expenses_ExpenseId",
                table: "Transactions",
                column: "ExpenseId",
                principalTable: "Expenses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Expenses_ExpenseId",
                table: "Transactions");

            migrationBuilder.AlterColumn<int>(
                name: "ExpenseId",
                table: "Transactions",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Expenses_ExpenseId",
                table: "Transactions",
                column: "ExpenseId",
                principalTable: "Expenses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
