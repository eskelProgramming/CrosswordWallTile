namespace CrosswordWallTile.Models
{
    /// <summary>
    /// Represents a single Stain that can be applied to a wall tile.
    /// </summary>
    public class Stain
    {
        /// <summary>
        /// The unique identifier for the Stain. Tracked by EF Core.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the Stain.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The price of the Stain.
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// The location of the image for the Stain.
        /// </summary>
        public string StainImage { get; set; }
    }
}
