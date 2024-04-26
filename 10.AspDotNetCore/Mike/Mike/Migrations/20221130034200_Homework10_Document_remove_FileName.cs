using Microsoft.EntityFrameworkCore.Migrations;

namespace Mike.Migrations
{
    public partial class Homework10_Document_remove_FileName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Homework10_Document");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Homework10_Document",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
