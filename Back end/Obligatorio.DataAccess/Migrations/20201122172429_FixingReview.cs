using Microsoft.EntityFrameworkCore.Migrations;

namespace Obligatorio.DataAccess.Migrations
{
    public partial class FixingReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Accommodations_acccommodationId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_acccommodationId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "acccommodationId",
                table: "Reviews");

            migrationBuilder.AddColumn<string>(
                name: "AcccommodationName",
                table: "Reviews",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcccommodationName",
                table: "Reviews");

            migrationBuilder.AddColumn<int>(
                name: "acccommodationId",
                table: "Reviews",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_acccommodationId",
                table: "Reviews",
                column: "acccommodationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Accommodations_acccommodationId",
                table: "Reviews",
                column: "acccommodationId",
                principalTable: "Accommodations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
