using Microsoft.EntityFrameworkCore.Migrations;

namespace Mike.Migrations
{
    public partial class EntityBase_add_IsActive_and_Order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Homework10_VideoGallery",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Homework10_VideoGallery",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Homework10_QuickLink",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Homework10_QuickLink",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Homework10_New",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Homework10_New",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Homework10_ImageGallery",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Homework10_ImageGallery",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Homework10_Event",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Homework10_Event",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Homework10_DocumentCategory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Homework10_DocumentCategory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Homework10_Document",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Homework10_Document",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Homework10_Announcement",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Homework10_Announcement",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Homework10_VideoGallery");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Homework10_VideoGallery");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Homework10_QuickLink");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Homework10_QuickLink");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Homework10_New");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Homework10_New");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Homework10_ImageGallery");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Homework10_ImageGallery");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Homework10_Event");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Homework10_Event");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Homework10_DocumentCategory");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Homework10_DocumentCategory");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Homework10_Document");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Homework10_Document");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Homework10_Announcement");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Homework10_Announcement");
        }
    }
}
