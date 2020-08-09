using Microsoft.EntityFrameworkCore.Migrations;

namespace FinanceTracker.API.Migrations
{
    public partial class AddCurrencyId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BaseCurrency",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "Users",
                nullable: false,
                defaultValue: 320);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CurrencyId",
                table: "Users",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Currencies_CurrencyId",
                table: "Users",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Currencies_CurrencyId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CurrencyId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "BaseCurrency",
                table: "Users",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");
        }
    }
}
