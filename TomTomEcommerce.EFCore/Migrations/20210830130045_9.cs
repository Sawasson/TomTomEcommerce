using Microsoft.EntityFrameworkCore.Migrations;

namespace TomTomEcommerce.EFCore.Migrations
{
    public partial class _9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentPath",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "DocumentId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Document_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_DocumentId",
                table: "Products",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_ProductId",
                table: "Document",
                column: "ProductId");

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

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropIndex(
                name: "IX_Products_DocumentId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DocumentId",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "DocumentPath",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
