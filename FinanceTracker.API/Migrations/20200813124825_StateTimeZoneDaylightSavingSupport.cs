using Microsoft.EntityFrameworkCore.Migrations;

namespace FinanceTracker.API.Migrations
{
    public partial class StateTimeZoneDaylightSavingSupport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UTC",
                table: "StateTimeZones",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "StateTimeZones",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SupportsDaylightSavingTime",
                table: "StateTimeZones",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TimeZoneInfoId",
                table: "StateTimeZones",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SupportsDaylightSavingTime",
                table: "StateTimeZones");

            migrationBuilder.DropColumn(
                name: "TimeZoneInfoId",
                table: "StateTimeZones");

            migrationBuilder.AlterColumn<string>(
                name: "UTC",
                table: "StateTimeZones",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "StateTimeZones",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);
        }
    }
}
