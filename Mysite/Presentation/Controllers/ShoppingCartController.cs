using Microsoft.AspNetCore.Mvc;
using Mysite.Core.Interfaces;

namespace Mysite.Presentation.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        public async Task<IActionResult> Index()
        {
            var cartItems = await _shoppingCartService.GetAllItemsAsync();
            return View(cartItems);
        }

        public async Task<IActionResult> AddItem(int productId)
        {
            await _shoppingCartService.AddItemAsync(productId);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveItem(int productId)
        {
            await _shoppingCartService.RemoveItemAsync(productId);
            return RedirectToAction("Index");
        }
    }
}