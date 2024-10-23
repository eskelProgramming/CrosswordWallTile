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

    /// <summary>
    /// A concrete Product class that implements the IProduct interface
    /// so that a List of products can be used in the Grid class. 
    /// </summary>
    public class Product : IProduct
    {
        /// <summary>
        /// The unique identifier for an instance of a Product
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The name of the Product
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The price of the Product without tax
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// The location of the Product image in the file system
        /// </summary>
        public string ProductImage { get; set; }

        /// <summary>
        /// The number of the Product in the users cart
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// The description of the Product. 
        /// </summary>
        public string Description { get; set; }
    }
}