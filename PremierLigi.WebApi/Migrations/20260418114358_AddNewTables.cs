using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PremierLigi.WebApi.Migrations
{
    public partial class AddNewTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stadium",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Stadium",
                table: "Matches");

            migrationBuilder.AddColumn<int>(
                name: "StadiumId",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GameWeekId",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RefereeId",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SeasonId",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Referees",
                columns: table => new
                {
                    RefereeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referees", x => x.RefereeId);
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    SeasonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeasonName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.SeasonId);
                });

            migrationBuilder.CreateTable(
                name: "Stadiums",
                columns: table => new
                {
                    StadiumId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StadiumName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stadiums", x => x.StadiumId);
                });

            migrationBuilder.CreateTable(
                name: "GameWeeks",
                columns: table => new
                {
                    GameWeekId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeekNumber = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SeasonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameWeeks", x => x.GameWeekId);
                    table.ForeignKey(
                        name: "FK_GameWeeks_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "SeasonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_StadiumId",
                table: "Teams",
                column: "StadiumId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_GameWeekId",
                table: "Matches",
                column: "GameWeekId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_RefereeId",
                table: "Matches",
                column: "RefereeId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_SeasonId",
                table: "Matches",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_GameWeeks_SeasonId",
                table: "GameWeeks",
                column: "SeasonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_GameWeeks_GameWeekId",
                table: "Matches",
                column: "GameWeekId",
                principalTable: "GameWeeks",
                principalColumn: "GameWeekId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Referees_RefereeId",
                table: "Matches",
                column: "RefereeId",
                principalTable: "Referees",
                principalColumn: "RefereeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Seasons_SeasonId",
                table: "Matches",
                column: "SeasonId",
                principalTable: "Seasons",
                principalColumn: "SeasonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Stadiums_StadiumId",
                table: "Teams",
                column: "StadiumId",
                principalTable: "Stadiums",
                principalColumn: "StadiumId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_GameWeeks_GameWeekId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Referees_RefereeId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Seasons_SeasonId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Stadiums_StadiumId",
                table: "Teams");

            migrationBuilder.DropTable(
                name: "GameWeeks");

            migrationBuilder.DropTable(
                name: "Referees");

            migrationBuilder.DropTable(
                name: "Stadiums");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropIndex(
                name: "IX_Teams_StadiumId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Matches_GameWeekId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_RefereeId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_SeasonId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "StadiumId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "GameWeekId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "RefereeId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "SeasonId",
                table: "Matches");

            migrationBuilder.AddColumn<string>(
                name: "Stadium",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Stadium",
                table: "Matches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
