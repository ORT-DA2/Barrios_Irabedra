using Microsoft.EntityFrameworkCore.Migrations;

namespace Obligatorio.DataAccess.Migrations
{
    public partial class AddedOneToManyRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RegionId",
                table: "TouristSpots",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RegionId",
                table: "TouristSpots",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
