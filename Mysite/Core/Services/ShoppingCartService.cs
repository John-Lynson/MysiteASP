using Mysite.Core.Interfaces;

namespace Mysite.Core.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IProductRepository _productRepository;

        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository, IProductRepository productRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _productRepository = productRepository;
        }

        public async Task<ShoppingCart> GetCartAsync(string userId)
        {
            return await _shoppingCartRepository.GetByUserIdAsync(userId);
        }

        public async Task AddToCartAsync(string userId, int productId, int quantity)
        {
            var cart = await _shoppingCartRepository.GetByUserIdAsync(userId);
            var product = await _productRepository.GetByIdAsync(productId);

            if (product != null)
            {
                if (cart == null)
                {
                    cart = new ShoppingCart { UserId = userId };
                    await _shoppingCartRepository.CreateAsync(cart);
                }

                var cartItem = cart.Items.FirstOrDefault(i => i.ProductId == productId);

                if (cartItem != null)
                {
                    cartItem.Quantity += quantity;
                }
                else
                {
                    cart.Items.Add(new ShoppingCartItem { ProductId = productId, Quantity = quantity });
                }

                await _shoppingCartRepository.UpdateAsync(cart);
            }
        }

        public async Task UpdateCartAsync(string userId, int productId, int quantity)
        {
            var cart = await _shoppingCartRepository.GetByUserIdAsync(userId);

            if (cart != null)
            {
                var cartItem = cart.Items.FirstOrDefault(i => i.ProductId == productId);

                if (cartItem != null)
                {
                    cartItem.Quantity = quantity;
                    await _shoppingCartRepository.UpdateAsync(cart);
                }
            }
        }

        public async Task RemoveFromCartAsync(string userId, int productId)
        {
            var cart = await _shoppingCartRepository.GetByUserIdAsync(userId);

            if (cart != null)
            {
                var cartItem = cart.Items.FirstOrDefault(i => i.ProductId == productId);

                if (cartItem != null)
                {
                    cart.Items.Remove(cartItem);
                    await _shoppingCartRepository.UpdateAsync(cart);
                }
            }
        }
    }
}