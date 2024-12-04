using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrosswordWallTile.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Grids",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "ProductImage",
                table: "Tiles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Grids",
                newName: "id");

            migrationBuilder.AlterColumn<string>(
                name: "ProductImage",
                table: "Tiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
