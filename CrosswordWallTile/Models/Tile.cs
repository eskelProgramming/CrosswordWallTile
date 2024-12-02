using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CrosswordWallTile.Models
{
    /// <summary>
    /// Represents a tile in the crossword wall that can be added to the cart
    /// </summary>
    public class Tile : IProduct
    {
        /// <summary>
        /// The unique identifier of the tile
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the tile
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// The consumer price of the tile without tax
        /// </summary>
        [Required]
        public double Price { get; set; }

        /// <summary>
        /// The location of the image of the tile
        /// </summary>
        public string? ProductImage { get; set; }


        /// <summary>
        /// The number of this tile in the cart
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// The description of the tile
        /// </summary>
        [Required]
        public string Description { get; set; } = "A tile for the crossword wall";

        /// <summary>
        /// The letter to be displayed on the tile
        /// </summary>
        public Char Letter { get; set; }

        /// <summary>
        /// The stain currently selected for this tile
        /// </summary>
        [Required]
        public Stain CurrentStain { get; set; }

        /// <summary>
        /// The x position of the tile on the crossword wall
        /// </summary>
        public int XPos { get; set; }

        /// <summary>
        /// The y position of the tile on the crossword wall
        /// </summary>
        public int YPos { get; set; }
    }
}
