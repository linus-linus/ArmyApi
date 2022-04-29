using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArmyAPI.Migrations
{
    public partial class InitialCreate10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Soldier",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Soldier",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                table: "Soldier");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Soldier");
        }
    }
}
