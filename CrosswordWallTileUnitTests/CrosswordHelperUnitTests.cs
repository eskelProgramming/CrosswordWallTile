using CrosswordWallTile.Data;
using CrosswordWallTile.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace CrosswordWallTileUnitTests
{
    /// <summary>
    /// Unit tests for the <see cref="CrosswordHelper"/> class.
    /// </summary>
    [TestClass]
    public class CrosswordHelperTests
    {

        /// <summary>
        /// The application database context used for testing.
        /// </summary>
        private ApplicationDbContext _context = null!;


        /// <summary>
        /// The SQLite connection used for the in-memory database.
        /// </summary>
        private SqliteConnection _connection = null!;


        /// <summary>
        /// The helper class used for crossword operations.
        /// </summary>
        private CrosswordHelper _helper = null!;

        /// <summary>
        /// Initializes the in-memory database and sets up the test context.
        /// </summary>
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

            _context.Frames.Add(new Frame
            {
                Id = 1,
                Name = "Frame1",
                ProductImage = "Frame1.png",
                Description = "Test frame"
            });
            _context.Tiles.Add(new Tile
            {
                Id = 1,
                Name = "Tile1",
                ProductImage = "Tile1.png",
                Description = "Test Tile",
                CurrentStain = new Stain
                {
                    Id = 1,
                    Name = "Stain 1",
                    Price = 9.99,
                    StainImage = "Stain1.png",
                    AllowedFontColors = new List<string> { "Black" }
                }
            });
            _context.SaveChanges();

            _helper = new CrosswordHelper(_context);
        }

        /// <summary>
        /// Cleans up the in-memory database and disposes of the test context.
        /// </summary>
        [TestCleanup]
        public void Cleanup()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
            _connection.Close();
        }

        /// <summary>
        /// Tests that <see cref="CrosswordHelper.GetAllProductsAsync"/> returns all products.
        /// </summary>
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

        /// <summary>
        /// Tests that <see cref="CrosswordHelper.AddFrameAsync"/> adds a frame to the database.
        /// </summary>
        [TestMethod]
        public async Task AddFrameAsync_AddsFrameToDatabase()
        {
            // Arrange
            var newFrame = new Frame
            {
                Id = 2,
                Name = "Frame2",
                ProductImage = "Frame2.png",
                Description = "Test frame"
            };

            // Act
            await _helper.AddFrameAsync(newFrame);
            var frames = await _context.Frames.ToListAsync();

            // Assert
            Assert.AreEqual(2, frames.Count);
            Assert.IsTrue(frames.Any(f => f.Name == "Frame2"));
        }

        /// <summary>
        /// Tests that <see cref="CrosswordHelper.AddStainAsync"/> adds a stain to the database.
        /// </summary>
        [TestMethod]
        public async Task AddStainAsync_AddsStainToDatabase()
        {
            // Arrange
            var newStain = new Stain
            {
                Id = 2,
                Name = "Stain2",
                Price = 19.99,
                StainImage = "Stain2.png",
                AllowedFontColors = new List<string> { "Black" }
            };

            // Act
            await _helper.AddStainAsync(newStain);
            var stains = await _context.Stains.ToListAsync();

            // Assert
            Assert.AreEqual(2, stains.Count);
            Assert.IsTrue(stains.Any(s => s.Name == "Stain2"));
        }

        /// <summary>
        /// Tests that <see cref="CrosswordHelper.FindFrameByIdAsync"/> returns the correct frame.
        /// </summary>
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

        /// <summary>
        /// Tests that <see cref="CrosswordHelper.UpdateFrameAsync"/> updates a frame in the database.
        /// </summary>
        [TestMethod]
        public async Task UpdateFrame_UpdatesFrameInDatabase()
        {
            // Arrange
            var frameToUpdate = await _context.Frames.FindAsync(1);
            Assert.IsNotNull(frameToUpdate);
            frameToUpdate.Name = "UpdatedFrame";

            // Act
            await _helper.UpdateFrameAsync(frameToUpdate);
            var updatedFrame = await _context.Frames.FindAsync(1);

            // Assert
            Assert.IsNotNull(updatedFrame);
            Assert.AreEqual("UpdatedFrame", updatedFrame.Name);
        }

        /// <summary>
        /// Tests that <see cref="CrosswordHelper.DeleteFrameAsync"/> deletes a frame from the database.
        /// </summary>
        [TestMethod]
        public async Task DeleteFrameAsync_DeletesFrameFromDatabase()
        {
            // Arrange
            var frameToDelete = await _context.Frames.FindAsync(1);
            Assert.IsNotNull(frameToDelete);

            // Act
            await _helper.DeleteFrameAsync(frameToDelete);
            var frames = await _context.Frames.ToListAsync();

            // Assert
            Assert.AreEqual(0, frames.Count);
        }
    }
}
