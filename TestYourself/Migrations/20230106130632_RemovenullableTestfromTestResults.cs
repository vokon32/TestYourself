using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testtesttest.Migrations
{
    public partial class RemovenullableTestfromTestResults : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestResults_Tests_Tests",
                table: "TestResults");

            migrationBuilder.AlterColumn<int>(
                name: "Tests",
                table: "TestResults",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TestResults_Tests_Tests",
                table: "TestResults",
                column: "Tests",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestResults_Tests_Tests",
                table: "TestResults");

            migrationBuilder.AlterColumn<int>(
                name: "Tests",
                table: "TestResults",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TestResults_Tests_Tests",
                table: "TestResults",
                column: "Tests",
                principalTable: "Tests",
                principalColumn: "Id");
        }
    }
}
