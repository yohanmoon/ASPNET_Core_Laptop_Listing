using Microsoft.EntityFrameworkCore.Migrations;

namespace Mvc_Laptop_Manually.Data.Migrations
{
    public partial class ids : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ScreenSizes",
                newName: "ScreenSizeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Resolutions",
                newName: "ResolutionId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "RAMs",
                newName: "RAMId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "GPUs",
                newName: "GPUId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CPUs",
                newName: "CPUId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Brands",
                newName: "BrandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ScreenSizeId",
                table: "ScreenSizes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ResolutionId",
                table: "Resolutions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "RAMId",
                table: "RAMs",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "GPUId",
                table: "GPUs",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CPUId",
                table: "CPUs",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BrandId",
                table: "Brands",
                newName: "Id");
        }
    }
}
