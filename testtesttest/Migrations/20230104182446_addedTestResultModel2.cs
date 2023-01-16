using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testtesttest.Migrations
{
    public partial class addedTestResultModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestResults_Tests_TestResult",
                table: "TestResults");

            migrationBuilder.RenameColumn(
                name: "TestResult",
                table: "TestResults",
                newName: "Tests");

            migrationBuilder.RenameIndex(
                name: "IX_TestResults_TestResult",
                table: "TestResults",
                newName: "IX_TestResults_Tests");

            migrationBuilder.AddForeignKey(
                name: "FK_TestResults_Tests_Tests",
                table: "TestResults",
                column: "Tests",
                principalTable: "Tests",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestResults_Tests_Tests",
                table: "TestResults");

            migrationBuilder.RenameColumn(
                name: "Tests",
                table: "TestResults",
                newName: "TestResult");

            migrationBuilder.RenameIndex(
                name: "IX_TestResults_Tests",
                table: "TestResults",
                newName: "IX_TestResults_TestResult");

            migrationBuilder.AddForeignKey(
                name: "FK_TestResults_Tests_TestResult",
                table: "TestResults",
                column: "TestResult",
                principalTable: "Tests",
                principalColumn: "Id");
        }
    }
}
