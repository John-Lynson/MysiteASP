namespace MySite.Core.Services
{
    public interface IShoppingCartService
    {
        Task<ShoppingCart> GetCartAsync(string userId);
        Task AddToCartAsync(string userId, int productId, int quantity);
        Task UpdateCartAsync(string userId, int productId, int quantity);
        Task RemoveFromCartAsync(string userId, int productId);
    }
}
