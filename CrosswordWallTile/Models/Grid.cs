using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrosswordWallTile.Models
{
    /// <summary>
    /// Represents a Grid of <see cref="IProduct"/>. 
    /// </summary>
    public class Grid
    {
        /// <summary>
        /// The unique identifier for the Grid
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The words to be used in the Grid
        /// </summary>
        [Required]
        public string[] Words { get; set; }

        /// <summary>
        /// The height of the Grid as an Int, in <see cref="GridUnitOfMeasurement"/>
        /// </summary>
        [Required]
        public int GridHeight { get; set; }

        /// <summary>
        /// The width of the Grid as an Int, in <see cref="GridUnitOfMeasurement"/>
        /// </summary>
        [Required]
        public int GridWidth { get; set; }

        /// <summary>
        /// The unit of measurement provided by the user
        /// </summary>
        [Required]
        public string GridUnitOfMeasurement { get; set; }

        /// <summary>
        /// A 2D array of products that represents the grid. Not mapped because 2d arrays cannot be mapped easily by EF core.
        /// </summary>
        [NotMapped]
        public List<List<IProduct>> ProductGrid { get; set; }

        /// <summary>
        /// Generates the crossword and populates the ProductGrid with Tiles.
        /// </summary>
        /// <param name="words">List of words to include in the crossword.</param>
        public async Task GenerateCrosswordAndPopulateGridAsync(List<string> words)
        {
            CrosswordGenerator crosswordGen = new CrosswordGenerator(words);
            string[,] result = await Task.Run(() => crosswordGen.GetCrossword());

            ProductGrid = new List<List<IProduct>>();

            for (int i = 0; i < result.GetLength(0); i++)
            {
                var row = new List<IProduct>();
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    var letter = string.IsNullOrEmpty(result[i, j]) ? ' ' : result[i, j][0];
                    row.Add(new Tile
                    {
                        Id = i * result.GetLength(1) + j,
                        Name = $"Tile_{i}_{j}",
                        Price = 0, // Assign appropriate value if needed
                        ProductImage = string.Empty, // Assign appropriate value if needed
                        Quantity = 1,
                        Description = "Crossword Tile",
                        Letter = letter, // Use the 'letter' variable here
                        XPos = i,
                        YPos = j,
                        CurrentStain = new Stain() // Assign appropriate value if needed
                    });
                }
                ProductGrid.Add(row);
            }
        }
    }
}