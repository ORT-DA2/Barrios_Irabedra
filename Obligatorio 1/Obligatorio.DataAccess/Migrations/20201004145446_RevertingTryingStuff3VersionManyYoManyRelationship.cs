using Microsoft.EntityFrameworkCore.Migrations;

namespace Obligatorio.DataAccess.Migrations
{
    public partial class RevertingTryingStuff3VersionManyYoManyRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "TouristSpotCategory",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false),
                    TouristSpotId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TouristSpotCategory", x => new { x.TouristSpotId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_TouristSpotCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TouristSpotCategory_TouristSpots_TouristSpotId",
                        column: x => x.TouristSpotId,
                        principalTable: "TouristSpots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TouristSpotCategory_CategoryId",
                table: "TouristSpotCategory",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TouristSpotCategory");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "TouristSpots",
                type: "int",
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
    }
}
