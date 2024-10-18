namespace CrosswordWallTile.Models
{
    /// <summary>
    /// An interface for a Product
    /// </summary>
    public interface Product
    {
        /// <summary>
        /// The name of the product
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// The consumer price of the product
        /// </summary>
        public Double Price { get; set; }

        /// <summary>
        /// The string that points to the image of the product
        /// </summary>
        public String ProductImage { get; set; }

        /// <summary>
        /// The number of this product in the cart
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// The subtotal of the quantity times the price
        /// </summary>
        public Double Subtotal
        {
            get
            {
                return Quantity * Price;
            }
        }

        /// <summary>
        /// The description of the product
        /// </summary>
        public String Description { get; set; }
    }
}
