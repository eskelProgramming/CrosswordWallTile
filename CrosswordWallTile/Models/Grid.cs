using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CrosswordWallTile.Models
{
    /// <summary>
    /// Represents a grid of products. 
    /// </summary>
    public class Grid
    {
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
