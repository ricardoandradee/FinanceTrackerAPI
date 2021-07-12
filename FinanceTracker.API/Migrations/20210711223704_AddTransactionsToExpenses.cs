using Microsoft.EntityFrameworkCore.Migrations;

namespace FinanceTracker.API.Migrations
{
    public partial class AddTransactionsToExpenses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Expenses_ExpenseId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_ExpenseId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ExpenseId",
                table: "Transactions");

            migrationBuilder.AddColumn<int>(
                name: "TransactionId",
                table: "Expenses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_TransactionId",
                table: "Expenses",
                column: "TransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Transactions_TransactionId",
                table: "Expenses",
                column: "TransactionId",
                principalTable: "Transactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Transactions_TransactionId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_TransactionId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "Expenses");

            migrationBuilder.AddColumn<int>(
                name: "ExpenseId",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ExpenseId",
                table: "Transactions",
                column: "ExpenseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Expenses_ExpenseId",
                table: "Transactions",
                column: "ExpenseId",
                principalTable: "Expenses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
