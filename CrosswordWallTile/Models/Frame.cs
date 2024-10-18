namespace CrosswordWallTile.Models
{
    /// <summary>
    /// Represents a single Frame
    /// </summary>
    public class Frame : Product
    {
        /// <summary>
        /// The unique identifier of the Frame
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the Frame
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The price of the Frame
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// The location of the image of the Frame
        /// </summary>
        public string ProductImage { get; set; }

        /// <summary>
        /// The quantity of this Frame in the cart
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// The Description of the Frame
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The height of the Frame in inches
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// The width of the Frame in inches
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// The x position of the Frame in the crossword
        /// </summary>
        public int XPos { get; set; }

        /// <summary>
        /// The y position of the Frame in the crossword
        /// </summary>
        public int YPos { get; set; }
    }
}
