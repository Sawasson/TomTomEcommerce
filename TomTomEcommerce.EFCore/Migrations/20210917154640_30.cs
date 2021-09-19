using Microsoft.EntityFrameworkCore.Migrations;

namespace TomTomEcommerce.EFCore.Migrations
{
    public partial class _30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DistrictId",
                table: "Adresses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Adresses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Ships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ships", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_CityId",
                table: "Adresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_DistrictId",
                table: "Adresses",
                column: "DistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adresses_Cities_CityId",
                table: "Adresses",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Adresses_Districts_DistrictId",
                table: "Adresses",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresses_Cities_CityId",
                table: "Adresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Adresses_Districts_DistrictId",
                table: "Adresses");

            migrationBuilder.DropTable(
                name: "Ships");

            migrationBuilder.DropIndex(
                name: "IX_Adresses_CityId",
                table: "Adresses");

            migrationBuilder.DropIndex(
                name: "IX_Adresses_DistrictId",
                table: "Adresses");

            migrationBuilder.AlterColumn<int>(
                name: "DistrictId",
                table: "Adresses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Adresses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
