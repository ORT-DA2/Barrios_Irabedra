using Microsoft.EntityFrameworkCore.Migrations;

namespace Obligatorio.DataAccess.Migrations
{
    public partial class RevertingTryingStuff2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TouristSpots_Categories_CategoryId1",
                table: "TouristSpots");

            migrationBuilder.DropIndex(
                name: "IX_TouristSpots_CategoryId1",
                table: "TouristSpots");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "TouristSpots");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId1",
                table: "TouristSpots",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TouristSpots_CategoryId1",
                table: "TouristSpots",
                column: "CategoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TouristSpots_Categories_CategoryId1",
                table: "TouristSpots",
                column: "CategoryId1",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
