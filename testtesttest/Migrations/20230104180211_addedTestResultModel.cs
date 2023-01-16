using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testtesttest.Migrations
{
    public partial class addedTestResultModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    testId = table.Column<int>(type: "int", nullable: false),
                    TestResult = table.Column<int>(type: "int", nullable: true),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    AppUserResult = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    FinalScore = table.Column<double>(type: "float", nullable: false),
                    isPassed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestResults_AspNetUsers_AppUserResult",
                        column: x => x.AppUserResult,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TestResults_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestResults_Tests_TestResult",
                        column: x => x.TestResult,
                        principalTable: "Tests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestResults_AppUserResult",
                table: "TestResults",
                column: "AppUserResult");

            migrationBuilder.CreateIndex(
                name: "IX_TestResults_QuestionId",
                table: "TestResults",
                column: "QuestionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestResults_TestResult",
                table: "TestResults",
                column: "TestResult");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestResults");
        }
    }
}
