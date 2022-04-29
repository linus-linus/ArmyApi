using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArmyAPI.Migrations
{
    public partial class InitialCreate14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "Weapon",
                newName: "Capacity");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Weapon",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Weapon");

            migrationBuilder.RenameColumn(
                name: "Capacity",
                table: "Weapon",
                newName: "Weight");
        }
    }
}
