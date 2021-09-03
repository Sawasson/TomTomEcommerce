using Microsoft.EntityFrameworkCore.Migrations;

namespace TomTomEcommerce.EFCore.Migrations
{
    public partial class _14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DocumentId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_DocumentId",
                table: "Products",
                column: "DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Document_DocumentId",
                table: "Products",
                column: "DocumentId",
                principalTable: "Document",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Document_DocumentId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_DocumentId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DocumentId",
                table: "Products");
        }
    }
}
