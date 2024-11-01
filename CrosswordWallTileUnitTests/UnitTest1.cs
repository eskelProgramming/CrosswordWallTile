using CrosswordWallTile.Data;
using CrosswordWallTile.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrosswordWallTileUnitTests
{
    [TestClass]
    public class CrosswordHelperTests
    {
        private ApplicationDbContext _context;
        private SqliteConnection _connection;

        [TestInitialize]
        public void Setup()
        {
            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite(_connection)
                .Options;

            _context = new ApplicationDbContext(options);
            _context.Database.EnsureCreated();

            // Seed the in-memory database with test data
            _context.Frames.Add(new Frame { Id = 1, Name = "Frame1" });
            _context.Tiles.Add(new Tile { Id = 1, Name = "Tile1" });
            _context.SaveChanges();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
            _connection.Close();
        }

        [TestMethod]
        public async Task GetAllProductsAsync_ReturnsAllProducts()
        {
            // Arrange
            CrosswordHelper._context = _context;

            // Act
            var result = await CrosswordHelper.GetAllProductsAsync();

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.Any(p => p is Frame));
            Assert.IsTrue(result.Any(p => p is Tile));
        }

        [TestMethod]
        public async Task AddFrameAsync_AddsFrameToDatabase()
        {
            // Arrange
            CrosswordHelper._context = _context;
            var newFrame = new Frame { Id = 2, Name = "Frame2" };

            // Act
            await CrosswordHelper.AddFrameAsync(newFrame);
            var frames = await _context.Frames.ToListAsync();

            // Assert
            Assert.AreEqual(2, frames.Count);
            Assert.IsTrue(frames.Any(f => f.Name == "Frame2"));
        }
    }
}
