using System.ComponentModel.DataAnnotations;

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
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// The price of the Stain.
        /// </summary>
        [Required]
        public double Price { get; set; }

        /// <summary>
        /// The location of the image for the Stain.
        /// </summary>
        public string StainImage { get; set; }

        /// <summary>
        /// The font colors allowed with this Stain.
        /// </summary>
        public List<String> AllowedFontColors { get; set; }
    }
}
