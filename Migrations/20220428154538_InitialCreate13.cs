using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArmyAPI.Migrations
{
    public partial class InitialCreate13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Manufacturer",
                table: "Weapon",
                newName: "Country");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Weapon",
                newName: "Manufacturer");
        }
    }
}
