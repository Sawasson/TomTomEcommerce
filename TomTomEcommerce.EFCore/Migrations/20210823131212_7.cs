using Microsoft.EntityFrameworkCore.Migrations;

namespace TomTomEcommerce.EFCore.Migrations
{
    public partial class _7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Categories",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Categories");
        }
    }
}
