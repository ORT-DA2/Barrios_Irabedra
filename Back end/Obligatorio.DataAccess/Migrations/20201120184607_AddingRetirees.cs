using Microsoft.EntityFrameworkCore.Migrations;

namespace Obligatorio.DataAccess.Migrations
{
    public partial class AddingRetirees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Retirees",
                table: "Reservations",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Retirees",
                table: "Reservations");
        }
    }
}
