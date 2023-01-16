using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testtesttest.Migrations
{
    public partial class RemovenullableTestfromTestResults2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestResults_AspNetUsers_AppUserResult",
                table: "TestResults");

            migrationBuilder.DropForeignKey(
                name: "FK_TestResults_Tests_Tests",
                table: "TestResults");

            migrationBuilder.DropIndex(
                name: "IX_TestResults_AppUserResult",
                table: "TestResults");

            migrationBuilder.DropIndex(
                name: "IX_TestResults_Tests",
                table: "TestResults");

            migrationBuilder.DropColumn(
                name: "AppUserResult",
                table: "TestResults");

            migrationBuilder.DropColumn(
                name: "Tests",
                table: "TestResults");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "TestResults",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_TestResults_AppUserId",
                table: "TestResults",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TestResults_testId",
                table: "TestResults",
                column: "testId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestResults_AspNetUsers_AppUserId",
                table: "TestResults",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestResults_Tests_testId",
                table: "TestResults",
                column: "testId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestResults_AspNetUsers_AppUserId",
                table: "TestResults");

            migrationBuilder.DropForeignKey(
                name: "FK_TestResults_Tests_testId",
                table: "TestResults");

            migrationBuilder.DropIndex(
                name: "IX_TestResults_AppUserId",
                table: "TestResults");

            migrationBuilder.DropIndex(
                name: "IX_TestResults_testId",
                table: "TestResults");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "TestResults",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "AppUserResult",
                table: "TestResults",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Tests",
                table: "TestResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TestResults_AppUserResult",
                table: "TestResults",
                column: "AppUserResult");

            migrationBuilder.CreateIndex(
                name: "IX_TestResults_Tests",
                table: "TestResults",
                column: "Tests");

            migrationBuilder.AddForeignKey(
                name: "FK_TestResults_AspNetUsers_AppUserResult",
                table: "TestResults",
                column: "AppUserResult",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TestResults_Tests_Tests",
                table: "TestResults",
                column: "Tests",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
