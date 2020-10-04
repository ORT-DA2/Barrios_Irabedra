using Microsoft.EntityFrameworkCore.Migrations;

namespace Obligatorio.DataAccess.Migrations
{
    public partial class AddedDbSetOfFirstJoin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TouristSpotCategory_Categories_CategoryId",
                table: "TouristSpotCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_TouristSpotCategory_TouristSpots_TouristSpotId",
                table: "TouristSpotCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TouristSpotCategory",
                table: "TouristSpotCategory");

            migrationBuilder.RenameTable(
                name: "TouristSpotCategory",
                newName: "TouristSpotCategories");

            migrationBuilder.RenameIndex(
                name: "IX_TouristSpotCategory_CategoryId",
                table: "TouristSpotCategories",
                newName: "IX_TouristSpotCategories_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TouristSpotCategories",
                table: "TouristSpotCategories",
                columns: new[] { "TouristSpotId", "CategoryId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TouristSpotCategories_Categories_CategoryId",
                table: "TouristSpotCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TouristSpotCategories_TouristSpots_TouristSpotId",
                table: "TouristSpotCategories",
                column: "TouristSpotId",
                principalTable: "TouristSpots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TouristSpotCategories_Categories_CategoryId",
                table: "TouristSpotCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_TouristSpotCategories_TouristSpots_TouristSpotId",
                table: "TouristSpotCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TouristSpotCategories",
                table: "TouristSpotCategories");

            migrationBuilder.RenameTable(
                name: "TouristSpotCategories",
                newName: "TouristSpotCategory");

            migrationBuilder.RenameIndex(
                name: "IX_TouristSpotCategories_CategoryId",
                table: "TouristSpotCategory",
                newName: "IX_TouristSpotCategory_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TouristSpotCategory",
                table: "TouristSpotCategory",
                columns: new[] { "TouristSpotId", "CategoryId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TouristSpotCategory_Categories_CategoryId",
                table: "TouristSpotCategory",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TouristSpotCategory_TouristSpots_TouristSpotId",
                table: "TouristSpotCategory",
                column: "TouristSpotId",
                principalTable: "TouristSpots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
