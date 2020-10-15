using Microsoft.EntityFrameworkCore.Migrations;

namespace Obligatorio.DataAccess.Migrations
{
    public partial class Actualizacion6969 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChangeDescription",
                table: "Reservations");

            migrationBuilder.AddColumn<string>(
                name: "NewStatusDescription",
                table: "Reservations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewStatusDescription",
                table: "Reservations");

            migrationBuilder.AddColumn<string>(
                name: "ChangeDescription",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
