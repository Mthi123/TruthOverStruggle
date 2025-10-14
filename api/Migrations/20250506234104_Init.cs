using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JournalEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mood = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Struggle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalEntries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Scriptures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Passage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scriptures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Struggles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Root = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Struggles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JournalEntryStruggles",
                columns: table => new
                {
                    JournalEntryId = table.Column<int>(type: "int", nullable: false),
                    StruggleId = table.Column<int>(type: "int", nullable: false),
                    DateLinked = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalEntryStruggles", x => new { x.JournalEntryId, x.StruggleId });
                    table.ForeignKey(
                        name: "FK_JournalEntryStruggles_JournalEntries_JournalEntryId",
                        column: x => x.JournalEntryId,
                        principalTable: "JournalEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JournalEntryStruggles_Struggles_StruggleId",
                        column: x => x.StruggleId,
                        principalTable: "Struggles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StruggleScriptures",
                columns: table => new
                {
                    StruggleId = table.Column<int>(type: "int", nullable: false),
                    ScriptureId = table.Column<int>(type: "int", nullable: false),
                    DateLinked = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StruggleScriptures", x => new { x.StruggleId, x.ScriptureId });
                    table.ForeignKey(
                        name: "FK_StruggleScriptures_Scriptures_ScriptureId",
                        column: x => x.ScriptureId,
                        principalTable: "Scriptures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StruggleScriptures_Struggles_StruggleId",
                        column: x => x.StruggleId,
                        principalTable: "Struggles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryStruggles_StruggleId",
                table: "JournalEntryStruggles",
                column: "StruggleId");

            migrationBuilder.CreateIndex(
                name: "IX_StruggleScriptures_ScriptureId",
                table: "StruggleScriptures",
                column: "ScriptureId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JournalEntryStruggles");

            migrationBuilder.DropTable(
                name: "StruggleScriptures");

            migrationBuilder.DropTable(
                name: "JournalEntries");

            migrationBuilder.DropTable(
                name: "Scriptures");

            migrationBuilder.DropTable(
                name: "Struggles");
        }
    }
}
