using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArmyAPI.Migrations
{
    public partial class InitialCreate31 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Vehicle",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Vehicle");
        }
    }
}
