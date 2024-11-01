﻿using CrosswordWallTile.Data;
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
        public static ApplicationDbContext _context = new ApplicationDbContext();


        
        /// <summary>
        /// Retrieves all products from the database, including frames and tiles.
        /// </summary>
        /// <returns>A list of all products implementing the IProduct interface.</returns>
        public static async Task<List<IProduct>> GetAllProductsAsync()
        {
            var frames = await _context.Frames.ToListAsync<IProduct>();
            var tiles = await _context.Tiles.ToListAsync<IProduct>();

            var allProducts = frames.Concat(tiles).ToList();
            return allProducts;
        }

        
        /// <summary>
        /// Adds a new frame to the database asynchronously.
        /// </summary>
        /// <param name="frame">The frame object to be added to the database.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static async Task AddFrameAsync(Frame frame)
        {
            _context.Add(frame);
            await _context.SaveChangesAsync();
        }
    }
}