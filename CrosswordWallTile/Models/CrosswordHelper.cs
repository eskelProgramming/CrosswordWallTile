using CrosswordWallTile.Data;
using Microsoft.EntityFrameworkCore;

namespace CrosswordWallTile.Models
{
    /// <summary>
    /// A static helper class for the Crossword project. 
    /// </summary>
    public static class CrosswordHelper
    {
        /// <summary>
        /// A list of all stains in the database.
        /// </summary>
        public static List<Stain> Stains { get; set; }

        /// <summary>
        /// A DbContext object that is used to interact with the database.
        /// </summary>
        public static DbContext _context = new ApplicationDbContext();
    }
}
