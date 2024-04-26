using Microsoft.EntityFrameworkCore.Migrations;

namespace Mike.Migrations
{
    public partial class Homework10_Navigation_add_Order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Homework10_Navigation",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "Homework10_Navigation");
        }
    }
}
