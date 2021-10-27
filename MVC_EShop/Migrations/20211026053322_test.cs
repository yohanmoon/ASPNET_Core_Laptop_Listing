using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_EShop.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Laptop",
                table: "Laptop");

            migrationBuilder.RenameTable(
                name: "Laptop",
                newName: "Laptops");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Laptops",
                table: "Laptops",
                column: "LaptopId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Laptops",
                table: "Laptops");

            migrationBuilder.RenameTable(
                name: "Laptops",
                newName: "Laptop");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Laptop",
                table: "Laptop",
                column: "LaptopId");
        }
    }
}
