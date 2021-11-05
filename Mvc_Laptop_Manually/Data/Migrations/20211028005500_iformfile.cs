using Microsoft.EntityFrameworkCore.Migrations;

namespace Mvc_Laptop_Manually.Data.Migrations
{
    public partial class iformfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Laptops",
                newName: "ImageName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageName",
                table: "Laptops",
                newName: "ImageUrl");
        }
    }
}
