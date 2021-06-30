using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinanceTracker.API.Migrations
{
    public partial class AddUserLogginHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastActive",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "UserLoginHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 30, nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    ActionDateTime = table.Column<DateTimeOffset>(nullable: false),
                    IsSuccessful = table.Column<bool>(nullable: false),
                    IPAddress = table.Column<string>(maxLength: 20, nullable: false),
                    GeoLocation = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLoginHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLoginHistories_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserLoginHistories_UserId",
                table: "UserLoginHistories",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLoginHistories");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastActive",
                table: "Users",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
