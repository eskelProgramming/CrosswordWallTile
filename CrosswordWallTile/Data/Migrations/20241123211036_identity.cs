using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrosswordWallTile.Data.Migrations
{
    /// <inheritdoc />
    public partial class identity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GridUnitOfMeasurment",
                table: "Grids",
                newName: "GridUnitOfMeasurement");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GridUnitOfMeasurement",
                table: "Grids",
                newName: "GridUnitOfMeasurment");
        }
    }
}
