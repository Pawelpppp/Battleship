using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Battleship.Infrastructure.Migrations
{
    public partial class GameMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Board_Games_GameId",
                schema: "BattleshipDB",
                table: "Board");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Games",
                schema: "BattleshipDB",
                table: "Games");

            migrationBuilder.RenameTable(
                name: "Games",
                schema: "BattleshipDB",
                newName: "Game",
                newSchema: "BattleshipDB");

            migrationBuilder.RenameColumn(
                name: "GameId",
                schema: "BattleshipDB",
                table: "Board",
                newName: "gameOwner_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Board_GameId",
                schema: "BattleshipDB",
                table: "Board",
                newName: "IX_Board_gameOwner_Id");

            migrationBuilder.RenameColumn(
                name: "LastModified",
                schema: "BattleshipDB",
                table: "Game",
                newName: "lastModified");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                schema: "BattleshipDB",
                table: "Game",
                newName: "creationDate");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "BattleshipDB",
                table: "Game",
                newName: "id");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "lastModified",
                schema: "BattleshipDB",
                table: "Game",
                type: "timestamp with time zone",
                nullable: true,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "creationDate",
                schema: "BattleshipDB",
                table: "Game",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<bool>(
                name: "isBoardAMove",
                schema: "BattleshipDB",
                table: "Game",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Game",
                schema: "BattleshipDB",
                table: "Game",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Board_Game_gameOwner_Id",
                schema: "BattleshipDB",
                table: "Board",
                column: "gameOwner_Id",
                principalSchema: "BattleshipDB",
                principalTable: "Game",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Board_Game_gameOwner_Id",
                schema: "BattleshipDB",
                table: "Board");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Game",
                schema: "BattleshipDB",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "isBoardAMove",
                schema: "BattleshipDB",
                table: "Game");

            migrationBuilder.RenameTable(
                name: "Game",
                schema: "BattleshipDB",
                newName: "Games",
                newSchema: "BattleshipDB");

            migrationBuilder.RenameColumn(
                name: "gameOwner_Id",
                schema: "BattleshipDB",
                table: "Board",
                newName: "GameId");

            migrationBuilder.RenameIndex(
                name: "IX_Board_gameOwner_Id",
                schema: "BattleshipDB",
                table: "Board",
                newName: "IX_Board_GameId");

            migrationBuilder.RenameColumn(
                name: "lastModified",
                schema: "BattleshipDB",
                table: "Games",
                newName: "LastModified");

            migrationBuilder.RenameColumn(
                name: "creationDate",
                schema: "BattleshipDB",
                table: "Games",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "BattleshipDB",
                table: "Games",
                newName: "Id");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastModified",
                schema: "BattleshipDB",
                table: "Games",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValueSql: "NOW()");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreationDate",
                schema: "BattleshipDB",
                table: "Games",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Games",
                schema: "BattleshipDB",
                table: "Games",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Board_Games_GameId",
                schema: "BattleshipDB",
                table: "Board",
                column: "GameId",
                principalSchema: "BattleshipDB",
                principalTable: "Games",
                principalColumn: "Id");
        }
    }
}
