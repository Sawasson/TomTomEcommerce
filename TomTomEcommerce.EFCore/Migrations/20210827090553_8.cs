using Microsoft.EntityFrameworkCore.Migrations;

namespace TomTomEcommerce.EFCore.Migrations
{
    public partial class _8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DocumentPath",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentId",
                table: "Categories",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_ParentId",
                table: "Categories",
                column: "ParentId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_ParentId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ParentId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DocumentPath",
                table: "Products");
        }
    }
}
