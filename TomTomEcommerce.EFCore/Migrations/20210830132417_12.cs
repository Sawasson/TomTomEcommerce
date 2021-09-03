using Microsoft.EntityFrameworkCore.Migrations;

namespace TomTomEcommerce.EFCore.Migrations
{
    public partial class _12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Document_DocumentId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "DocumentId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AlterColumn<int>(
                name: "DocumentId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Document_DocumentId",
                table: "Products",
                column: "DocumentId",
                principalTable: "Document",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
