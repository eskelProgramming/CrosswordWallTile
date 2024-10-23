using CrosswordWallTile.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CrosswordWallTile.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        // no-args constructor for EF core
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Grid> Grids { get; set; }

        public DbSet<Frame> Frames { get; set; }

        public DbSet<Tile> Tiles { get; set; }

        public DbSet<Stain> Stains { get; set; }
    }
}
