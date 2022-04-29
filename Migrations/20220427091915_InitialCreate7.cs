using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArmyAPI.Migrations
{
    public partial class InitialCreate7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Soldier",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Soldier",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Soldier");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Soldier",
                newName: "Name");
        }
    }
}
