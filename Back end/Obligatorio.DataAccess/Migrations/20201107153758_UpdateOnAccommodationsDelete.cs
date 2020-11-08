using Microsoft.EntityFrameworkCore.Migrations;

namespace Obligatorio.DataAccess.Migrations
{
    public partial class UpdateOnAccommodationsDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageWrappers_Accommodations_AccommodationId",
                table: "ImageWrappers");

            migrationBuilder.DropForeignKey(
                name: "FK_TouristSpots_Regions_RegionId",
                table: "TouristSpots");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageWrappers_Accommodations_AccommodationId",
                table: "ImageWrappers",
                column: "AccommodationId",
                principalTable: "Accommodations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TouristSpots_Regions_RegionId",
                table: "TouristSpots",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageWrappers_Accommodations_AccommodationId",
                table: "ImageWrappers");

            migrationBuilder.DropForeignKey(
                name: "FK_TouristSpots_Regions_RegionId",
                table: "TouristSpots");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageWrappers_Accommodations_AccommodationId",
                table: "ImageWrappers",
                column: "AccommodationId",
                principalTable: "Accommodations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TouristSpots_Regions_RegionId",
                table: "TouristSpots",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
