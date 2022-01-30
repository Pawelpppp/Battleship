using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Battleship.Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "BattleshipDB");

            migrationBuilder.CreateTable(
                name: "Games",
                schema: "BattleshipDB",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Board",
                schema: "BattleshipDB",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    isBattleshipsDestyroyed = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    GameId = table.Column<long>(type: "bigint", nullable: true),
                    creationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    lastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Board", x => x.id);
                    table.ForeignKey(
                        name: "FK_Board_Games_GameId",
                        column: x => x.GameId,
                        principalSchema: "BattleshipDB",
                        principalTable: "Games",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Battleship",
                schema: "BattleshipDB",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    isDestroyed = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    BoardId = table.Column<long>(type: "bigint", nullable: true),
                    CreationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Battleship", x => x.id);
                    table.ForeignKey(
                        name: "FK_Battleship_Board_BoardId",
                        column: x => x.BoardId,
                        principalSchema: "BattleshipDB",
                        principalTable: "Board",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Field",
                schema: "BattleshipDB",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    X = table.Column<int>(type: "integer", nullable: false),
                    Y = table.Column<int>(type: "integer", nullable: false),
                    BattleshipId = table.Column<long>(type: "bigint", nullable: true),
                    BoardId = table.Column<long>(type: "bigint", nullable: true),
                    CreationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Field", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Field_Battleship_BattleshipId",
                        column: x => x.BattleshipId,
                        principalSchema: "BattleshipDB",
                        principalTable: "Battleship",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Field_Board_BoardId",
                        column: x => x.BoardId,
                        principalSchema: "BattleshipDB",
                        principalTable: "Board",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Battleship_BoardId",
                schema: "BattleshipDB",
                table: "Battleship",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Board_GameId",
                schema: "BattleshipDB",
                table: "Board",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Field_BattleshipId",
                schema: "BattleshipDB",
                table: "Field",
                column: "BattleshipId");

            migrationBuilder.CreateIndex(
                name: "IX_Field_BoardId",
                schema: "BattleshipDB",
                table: "Field",
                column: "BoardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Field",
                schema: "BattleshipDB");

            migrationBuilder.DropTable(
                name: "Battleship",
                schema: "BattleshipDB");

            migrationBuilder.DropTable(
                name: "Board",
                schema: "BattleshipDB");

            migrationBuilder.DropTable(
                name: "Games",
                schema: "BattleshipDB");
        }
    }
}
