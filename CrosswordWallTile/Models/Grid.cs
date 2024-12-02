using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrosswordWallTile.Models

//This is a comment for testing purposes
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

        public void SeparateWords(string allWords)
        {
            throw new NotImplementedException();
        }

        public void ShuffleArray()
        {
            throw new NotImplementedException();
        }

        public void GenerateCrossword()
        {
            throw new NotImplementedException();
        }

        public bool CanPlaceWord(string word, int x, int y, string direction)
        {
            throw new NotImplementedException();
        }

        public void PlaceWord(string word, int x, int y, string direction)
        {
            throw new NotImplementedException();
        }

        public void FindPlacement(string word)
        {
            throw new NotImplementedException();
        }

        public void RenderCrossword()
        {
            throw new NotImplementedException();
        }
    }
}
