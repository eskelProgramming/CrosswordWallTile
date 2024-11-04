using CrosswordWallTile.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrosswordWallTile.Controllers
{
    public class ProductController : Controller
    {
        public async Task<IActionResult> ProductsAsync()
        {
            List<IProduct> products = await CrosswordHelper.GetAllProductsAsync();
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
            // Check if the frame is valid
            if (!ModelState.IsValid)
            {
                return View(frame);
            }

            // Add the frame to the database
            await CrosswordHelper.AddFrameAsync(frame);
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
            // Check if the frame is valid
            if (!ModelState.IsValid)
            {
                return View(stain);
            }

            // Add the Stain to the database
            await CrosswordHelper.AddStainAsync(stain);
            return RedirectToAction("Products");
        }
    }
}