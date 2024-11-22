using CrosswordWallTile.Data;
using Microsoft.EntityFrameworkCore;

namespace CrosswordWallTile.Models
{
    /// <summary>
    /// A static helper class for the Crossword project. 
    /// </summary>
    public class CrosswordHelper
    {
        public List<Stain> Stains { get; set; }

        private readonly ApplicationDbContext _context;

        public CrosswordHelper(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<IProduct>> GetAllProductsAsync()
        {
            var frames = await _context.Frames.ToListAsync<IProduct>();
            var tiles = await _context.Tiles.ToListAsync<IProduct>();
            return frames.Concat(tiles).ToList();
        }

        public async Task AddFrameAsync(Frame frame)
        {
            _context.Frames.Add(frame);
            await _context.SaveChangesAsync();
        }

        public async Task AddStainAsync(Stain stain)
        {
            _context.Stains.Add(stain);
            await _context.SaveChangesAsync();
        }

        public async Task<Frame> FindFrameByIdAsync(int id)
        {
            return await _context.Frames.FindAsync(id);
        }

        public async Task UpdateFrameAsync(Frame frame)
        {
            _context.Frames.Update(frame);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFrameAsync(Frame frame)
        {
            _context.Frames.Remove(frame);
            await _context.SaveChangesAsync();
        }
    }
}