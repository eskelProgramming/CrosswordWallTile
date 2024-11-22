using CrosswordWallTile.Data;
using CrosswordWallTile.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace CrosswordWallTileUnitTests
{
    [TestClass]
    public class CrosswordHelperTests
    {
        private ApplicationDbContext _context;
        private SqliteConnection _connection;
        private CrosswordHelper _helper;

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

            _context.Frames.Add(new Frame { Id = 1, Name = "Frame1", ProductImage = "Frame1.png", Description = "Test frame" });
            _context.Tiles.Add(new Tile { Id = 1, Name = "Tile1", ProductImage = "Tile1.png", Description = "Test Tile", CurrentStain = new Stain() { Id = 1, Name = "Stain 1", Price = 9.99, StainImage = "Stain1.png" } });
            _context.SaveChanges();

            _helper = new CrosswordHelper(_context);
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
            // Act
            var result = await _helper.GetAllProductsAsync();

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.Any(p => p is Frame));
            Assert.IsTrue(result.Any(p => p is Tile));
        }

        [TestMethod]
        public async Task AddFrameAsync_AddsFrameToDatabase()
        {
            // Arrange
            var newFrame = new Frame { Id = 2, Name = "Frame2", ProductImage = "Frame2.png", Description = "Test frame" };

            // Act
            await _helper.AddFrameAsync(newFrame);
            var frames = await _context.Frames.ToListAsync();

            // Assert
            Assert.AreEqual(2, frames.Count);
            Assert.IsTrue(frames.Any(f => f.Name == "Frame2"));
        }

        [TestMethod]
        public async Task AddStainAsync_AddsStainToDatabase()
        {
            // Arrange
            var newStain = new Stain { Id = 2, Name = "Stain2", Price = 19.99, StainImage = "Stain2.png" };

            // Act
            await _helper.AddStainAsync(newStain);
            var stains = await _context.Stains.ToListAsync();

            // Assert
            Assert.AreEqual(2, stains.Count);
            Assert.IsTrue(stains.Any(s => s.Name == "Stain2"));
        }

        [TestMethod]
        public async Task FindFrameByIdAsync_ReturnsCorrectFrame()
        {
            // Act
            var result = await _helper.FindFrameByIdAsync(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("Frame1", result.Name);
        }

        [TestMethod]
        public async Task UpdateFrame_UpdatesFrameInDatabase()
        {
            // Arrange
            var frameToUpdate = await _context.Frames.FindAsync(1);
            frameToUpdate.Name = "UpdatedFrame";

            // Act
            await _helper.UpdateFrameAsync(frameToUpdate);
            var updatedFrame = await _context.Frames.FindAsync(1);

            // Assert
            Assert.IsNotNull(updatedFrame);
            Assert.AreEqual("UpdatedFrame", updatedFrame.Name);
        }
    }
}
