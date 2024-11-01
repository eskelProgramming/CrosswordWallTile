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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-CrosswordWallTile-27c23987-b2af-469f-b5ce-fb6053e41f05;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        public virtual DbSet<Grid> Grids { get; set; }

        public virtual DbSet<Frame> Frames { get; set; }

        public virtual DbSet<Tile> Tiles { get; set; }

        public virtual DbSet<Stain> Stains { get; set; }
    }
}
