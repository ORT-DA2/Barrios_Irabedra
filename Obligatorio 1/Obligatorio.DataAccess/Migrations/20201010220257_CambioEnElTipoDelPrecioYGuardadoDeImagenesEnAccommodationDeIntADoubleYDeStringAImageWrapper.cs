using Microsoft.EntityFrameworkCore.Migrations;

namespace Obligatorio.DataAccess.Migrations
{
    public partial class CambioEnElTipoDelPrecioYGuardadoDeImagenesEnAccommodationDeIntADoubleYDeStringAImageWrapper : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adress",
                table: "Accommodations");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Accommodations");

            migrationBuilder.AlterColumn<double>(
                name: "PricePerNight",
                table: "Accommodations",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Accommodations",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ImageWrappers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(nullable: true),
                    AccommodationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageWrappers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageWrappers_Accommodations_AccommodationId",
                        column: x => x.AccommodationId,
                        principalTable: "Accommodations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageWrappers_AccommodationId",
                table: "ImageWrappers",
                column: "AccommodationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageWrappers");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Accommodations");

            migrationBuilder.AlterColumn<int>(
                name: "PricePerNight",
                table: "Accommodations",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "Accommodations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Accommodations",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
