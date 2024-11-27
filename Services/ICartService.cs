using TranaWarePcApp.Models;

namespace TranaWarePcApp.Services
{
    public interface ICartService
    {
        Task<List<CartItem>> GetCartItemsAsync(string userId);
        Task ClearCartAsync(string userId);
        Task AddToCartAsync(int productId, int quantity);
        void RemoveFromCart(int productId);
        void ClearCart();
        Cart GetCart();
    }
}
