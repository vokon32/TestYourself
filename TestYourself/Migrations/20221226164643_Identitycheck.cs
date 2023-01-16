using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testtesttest.Migrations
{
    public partial class Identitycheck : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Tests",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tests_AppUserId",
                table: "Tests",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_AspNetUsers_AppUserId",
                table: "Tests",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_AspNetUsers_AppUserId",
                table: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_Tests_AppUserId",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Tests");
        }
    }
}
