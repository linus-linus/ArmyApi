using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArmyAPI.Migrations
{
    public partial class InitialCreate15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Caliber",
                table: "Weapon");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "Weapon");

            migrationBuilder.AddColumn<bool>(
                name: "Damage",
                table: "Weapon",
                type: "INTEGER",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Damage",
                table: "Weapon");

            migrationBuilder.AddColumn<int>(
                name: "Caliber",
                table: "Weapon",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Length",
                table: "Weapon",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
