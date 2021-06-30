using Microsoft.EntityFrameworkCore.Migrations;

namespace FinanceTracker.API.Migrations
{
    public partial class AddIsDeletedToBank : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Banks",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Banks");
        }
    }
}
