using CrosswordWallTile.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrosswordWallTile.Controllers
{
    public class ProductController : Controller
    {
        private readonly CrosswordHelper _helper;

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
    }
}