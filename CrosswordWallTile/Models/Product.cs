using System.ComponentModel.DataAnnotations;

namespace CrosswordWallTile.Models
{
    /// <summary>
    /// An interface for a Product
    /// </summary>
    public interface IProduct
    {
        /// <summary>
        /// The unique identifier for an instance of a product
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// The name of the product
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The consumer price of the product
        /// </summary>
        double Price { get; set; }

        /// <summary>
        /// The string that points to the image of the product
        /// </summary>
        string ProductImage { get; set; }

        /// <summary>
        /// The number of this product in the cart
        /// </summary>
        int Quantity { get; set; }

        /// <summary>
        /// The description of the product
        /// </summary>
        string Description { get; set; }
    }
}