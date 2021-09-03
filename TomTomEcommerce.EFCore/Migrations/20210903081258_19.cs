using Microsoft.EntityFrameworkCore.Migrations;

namespace TomTomEcommerce.EFCore.Migrations
{
    public partial class _19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PathLarge",
                table: "ProductImages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PathMedium",
                table: "ProductImages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PathSmall",
                table: "ProductImages",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PathLarge",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "PathMedium",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "PathSmall",
                table: "ProductImages");
        }
    }
}
