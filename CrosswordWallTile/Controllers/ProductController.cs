using CrosswordWallTile.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrosswordWallTile.Controllers
{
    public class ProductController : Controller
    {
        private readonly CrosswordHelper _helper;
        private static readonly string[] WordSeparators = new[] { ", ", ",", " " };

        public ProductController(CrosswordHelper helper)
        {
            _helper = helper;
        }

        public async Task<IActionResult> ProductsAsync()
        {
            List<IProduct> products = await _helper.GetAllProductsAsync();
            return View(products);
        }

        [HttpGet]
        public IActionResult CreateFrame()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFrame(Frame frame)
        {
            if (!ModelState.IsValid)
            {
                return View(frame);
            }

            await _helper.AddFrameAsync(frame);
            return RedirectToAction("Products");
        }

        [HttpGet]
        public IActionResult CreateStain()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateStain(Stain stain)
        {
            if (!ModelState.IsValid)
            {
                return View(stain);
            }

            await _helper.AddStainAsync(stain);
            return RedirectToAction("Products");
        }

        [HttpGet]
        public async Task<IActionResult> EditFrame(int id)
        {
            Frame? frameToEdit = await _helper.FindFrameByIdAsync(id);

            if (frameToEdit == null)
            {
                return NotFound();
            }

            return View(frameToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> EditFrame(Frame frame)
        {
            if (ModelState.IsValid)
            {
                await _helper.UpdateFrameAsync(frame);
                TempData["Message"] = $"{frame.Name} was updated successfully";
                return RedirectToAction("Products");
            }

            return View(frame);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteFrame(int id)
        {
            Frame? frameToDelete = await _helper.FindFrameByIdAsync(id);
            if (frameToDelete == null)
            {
                return NotFound();
            }
            return View(frameToDelete);
        }

        [HttpPost, ActionName("DeleteFrame")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Frame frameToDelete = await _helper.FindFrameByIdAsync(id);
            if (frameToDelete != null)
            {
                await _helper.DeleteFrameAsync(frameToDelete);
                TempData["Message"] = $"{frameToDelete.Name} was deleted successfully";
                return RedirectToAction("Products");
            }
            return View(frameToDelete);
        }

        [HttpGet]
        public IActionResult CrosswordGenerator()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrosswordGenerator(string Words)
        {
            if (Words == null)
            {
                ViewBag.Message = "Please enter a list of words to generate a crossword";
                return View();
            }
            else
            {
                List<string> words = Words.Split(WordSeparators, StringSplitOptions.RemoveEmptyEntries).ToList();
                Grid grid = new Grid();
                await grid.GenerateCrosswordAndPopulateGridAsync(words);
                return View(grid);
            }
        }
    }
}