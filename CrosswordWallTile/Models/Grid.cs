using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrosswordWallTile.Models
{
    /// <summary>
    /// Represents a grid of products. 
    /// </summary>
    public class Grid
    {
        /// <summary>
        /// The unique identifier for the grid
        /// </summary>
        [Key]
        public int id { get; set; }

        /// <summary>
        /// The words to be used in the grid
        /// </summary>
        public string[] Words { get; set; }

        /// <summary>
        /// The height of the grid as an int, in <see cref="GridUnitOfMeasurment"/>
        /// </summary>
        public int GridHeight { get; set; }

        /// <summary>
        /// The width of the grid as an int, in <see cref="GridUnitOfMeasurment"/>
        /// </summary>
        public int GridWidth { get; set; }

        /// <summary>
        /// The unit of measurement provided by the user
        /// </summary>
        public string GridUnitOfMeasurment { get; set; }

        /// <summary>
        /// A 2D array of products that represents the grid
        /// </summary>
        //Not mapped because 2d arrays can't be mapped easily by EF core
        [NotMapped]
        public List<List<Product>> ProductGrid { get; set; }

        public void SeperateWords(string allWords)
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
