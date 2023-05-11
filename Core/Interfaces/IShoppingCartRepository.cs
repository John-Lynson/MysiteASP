using Core.Models;

namespace Core.Interfaces
{
    public interface IShoppingCartRepository
    {
        Task<ShoppingCart> GetShoppingCartByIdAsync(string id);
        Task AddProductAsync(string shoppingCartId, Product product);
        Task RemoveProductAsync(string shoppingCartId, Product product);
        Task ClearAsync(string shoppingCartId);
    }
}
