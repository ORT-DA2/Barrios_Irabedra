using Microsoft.EntityFrameworkCore.Migrations;

namespace Obligatorio.DataAccess.Migrations
{
    public partial class CategoryHasBeenUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "TouristSpots",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TouristSpots_CategoryId",
                table: "TouristSpots",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_TouristSpots_Categories_CategoryId",
                table: "TouristSpots",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TouristSpots_Categories_CategoryId",
                table: "TouristSpots");

            migrationBuilder.DropIndex(
                name: "IX_TouristSpots_CategoryId",
                table: "TouristSpots");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "TouristSpots");
        }
    }
}
