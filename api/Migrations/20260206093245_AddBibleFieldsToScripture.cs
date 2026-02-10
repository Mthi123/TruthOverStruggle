using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddBibleFieldsToScripture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Passage",
                table: "Scriptures",
                newName: "VerseText");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Scriptures",
                newName: "Translation");

            migrationBuilder.AddColumn<string>(
                name: "BibleApiId",
                table: "Scriptures",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BookName",
                table: "Scriptures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Chapter",
                table: "Scriptures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VerseEnd",
                table: "Scriptures",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VerseStart",
                table: "Scriptures",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BibleApiId",
                table: "Scriptures");

            migrationBuilder.DropColumn(
                name: "BookName",
                table: "Scriptures");

            migrationBuilder.DropColumn(
                name: "Chapter",
                table: "Scriptures");

            migrationBuilder.DropColumn(
                name: "VerseEnd",
                table: "Scriptures");

            migrationBuilder.DropColumn(
                name: "VerseStart",
                table: "Scriptures");

            migrationBuilder.RenameColumn(
                name: "VerseText",
                table: "Scriptures",
                newName: "Passage");

            migrationBuilder.RenameColumn(
                name: "Translation",
                table: "Scriptures",
                newName: "Description");
        }
    }
}
