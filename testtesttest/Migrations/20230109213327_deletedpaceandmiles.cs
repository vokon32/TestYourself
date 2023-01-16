using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testtesttest.Migrations
{
    public partial class deletedpaceandmiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mileage",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Pace",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Mileage",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Pace",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }
    }
}
