using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testtesttest.Migrations
{
    public partial class addedPropertyCanBePassedAgainToTestModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CanBePassedAgain",
                table: "Tests",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanBePassedAgain",
                table: "Tests");
        }
    }
}
