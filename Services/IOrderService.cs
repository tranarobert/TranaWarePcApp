using TranaWarePcApp.Models;
using System.Threading.Tasks;

namespace TranaWarePcApp.Services
{
    public interface IOrderService
    {
        Task<int> PlaceOrderAsync(string userId, List<CartItem> cartItems, decimal totalPrice);

        Task<List<Order>> GetOrdersByUserAsync(string userId);
        Task<Order> GetOrderByIdAsync(int id);
    }
}
