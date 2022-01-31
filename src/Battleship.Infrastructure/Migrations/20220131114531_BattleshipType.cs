using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Battleship.Infrastructure.Migrations
{
    public partial class BattleshipType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "type",
                schema: "BattleshipDB",
                table: "Battleship",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "type",
                schema: "BattleshipDB",
                table: "Battleship");
        }
    }
}
