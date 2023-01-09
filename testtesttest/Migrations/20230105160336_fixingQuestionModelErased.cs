using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testtesttest.Migrations
{
    public partial class fixingQuestionModelErased : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestResults_Questions_QuestionId",
                table: "TestResults");

            migrationBuilder.DropIndex(
                name: "IX_TestResults_QuestionId",
                table: "TestResults");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "TestResults");

            migrationBuilder.AddColumn<int>(
                name: "TestResultId",
                table: "Questions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TestResultId",
                table: "Questions",
                column: "TestResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_TestResults_TestResultId",
                table: "Questions",
                column: "TestResultId",
                principalTable: "TestResults",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_TestResults_TestResultId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_TestResultId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "TestResultId",
                table: "Questions");

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "TestResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TestResults_QuestionId",
                table: "TestResults",
                column: "QuestionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TestResults_Questions_QuestionId",
                table: "TestResults",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
