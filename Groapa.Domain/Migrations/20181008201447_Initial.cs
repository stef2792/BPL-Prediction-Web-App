using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Groapa.Domain.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MatchDetails",
                columns: table => new
                {
                    MatchID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AwayCorners = table.Column<int>(nullable: true),
                    AwayOnTarget = table.Column<int>(nullable: true),
                    AwayReds = table.Column<int>(nullable: true),
                    AwayShots = table.Column<int>(nullable: true),
                    AwayYellows = table.Column<int>(nullable: true),
                    B356A = table.Column<decimal>(nullable: true),
                    B365D = table.Column<decimal>(nullable: true),
                    B365H = table.Column<decimal>(nullable: true),
                    BWA = table.Column<decimal>(nullable: true),
                    BWD = table.Column<decimal>(nullable: true),
                    BWH = table.Column<decimal>(nullable: true),
                    HTAway = table.Column<int>(nullable: true),
                    HTHome = table.Column<int>(nullable: true),
                    HomeCorners = table.Column<int>(nullable: true),
                    HomeOnTarget = table.Column<int>(nullable: true),
                    HomeReds = table.Column<int>(nullable: true),
                    HomeShots = table.Column<int>(nullable: true),
                    HomeYellows = table.Column<int>(nullable: true),
                    Referee = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchDetails", x => x.MatchID);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    MatchID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AwayScore = table.Column<int>(nullable: true),
                    AwayTeam = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    HomeScore = table.Column<int>(nullable: true),
                    HomeTeam = table.Column<string>(nullable: true),
                    MatchDetailsMatchID = table.Column<int>(nullable: true),
                    Round = table.Column<int>(nullable: true),
                    Season = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.MatchID);
                    table.ForeignKey(
                        name: "FK_Matches_MatchDetails_MatchDetailsMatchID",
                        column: x => x.MatchDetailsMatchID,
                        principalTable: "MatchDetails",
                        principalColumn: "MatchID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_MatchDetailsMatchID",
                table: "Matches",
                column: "MatchDetailsMatchID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "MatchDetails");
        }
    }
}
