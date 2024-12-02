using CrosswordWallTile.Data;
using Microsoft.EntityFrameworkCore;

namespace CrosswordWallTile.Models
{
    /// <summary>
    /// A static helper class for the Crossword project. 
    /// </summary>
    public class CrosswordHelper
    {
        /// <summary>
        /// Gets or sets the list of stains.
        /// </summary>
        public List<Stain> Stains { get; set; }

        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CrosswordHelper"/> class.
        /// </summary>
        /// <param name="context">The application database context.</param>
        public CrosswordHelper(ApplicationDbContext context)
        {
            _context = context;
            Stains = _context.Stains.ToList();
        }

        /// <summary>
        /// Gets all products asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of products.</returns>
        public async Task<List<IProduct>> GetAllProductsAsync()
        {
            var frames = await _context.Frames.ToListAsync<IProduct>();
            var tiles = await _context.Tiles.ToListAsync<IProduct>();
            return frames.Concat(tiles).ToList();
        }

        /// <summary>
        /// Adds a frame asynchronously.
        /// </summary>
        /// <param name="frame">The frame to add.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task AddFrameAsync(Frame frame)
        {
            _context.Frames.Add(frame);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Adds a stain asynchronously.
        /// </summary>
        /// <param name="stain">The stain to add.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task AddStainAsync(Stain stain)
        {
            _context.Stains.Add(stain);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Finds a frame by its identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier of the frame.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the frame.</returns>
        public async Task<Frame> FindFrameByIdAsync(int id)
        {
            return await _context.Frames.FindAsync(id);
        }

        /// <summary>
        /// Updates a frame asynchronously.
        /// </summary>
        /// <param name="frame">The frame to update.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task UpdateFrameAsync(Frame frame)
        {
            _context.Frames.Update(frame);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a frame asynchronously.
        /// </summary>
        /// <param name="frame">The frame to delete.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task DeleteFrameAsync(Frame frame)
        {
            _context.Frames.Remove(frame);
            await _context.SaveChangesAsync();
        }
    }
}