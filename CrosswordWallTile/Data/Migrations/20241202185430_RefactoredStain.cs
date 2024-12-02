using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrosswordWallTile.Data.Migrations
{
    /// <inheritdoc />
    public partial class RefactoredStain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "AllowedFontColors",
                table: "Stains",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllowedFontColors",
                table: "Stains");
        }
    }
}
