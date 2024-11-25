using TranaWarePc.Models;
using TranaWarePc.Services;
using Microsoft.EntityFrameworkCore;


namespace TranaWarePc.Services
{
    public class OrderService : IOrderService
    {
        private readonly TranaWareContext _context;

        public OrderService(TranaWareContext context)
        {
            _context = context;
        }

        //public async Task PlaceOrderAsync(string userId, List<CartItem> cartItems, decimal totalPrice)
        //{
        //    var order = new Order
        //    {
        //        UserId = userId,
        //        TotalPrice = totalPrice,
        //        OrderItems = cartItems.Select(item => new OrderItem
        //        {
        //            ProductId = item.Product.Id,
        //            Quantity = item.Quantity,
        //            Price = item.Product.Price
        //        }).ToList()
        //    };

        //    _context.Orders.Add(order);
        //    await _context.SaveChangesAsync();
        //}

        public async Task<List<Order>> GetOrdersByUserAsync(string userId)
        {
            return await _context.Orders
                .Where(o => o.UserId == userId)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .ToListAsync();
        }

        async Task<Order> IOrderService.GetOrderByIdAsync(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task<int> PlaceOrderAsync(string userId, List<CartItem> cartItems, decimal totalPrice)
        {
            // Create a new order
            var order = new Order
            {
                UserId = userId,
                TotalPrice = totalPrice,
                OrderItems = cartItems.Select(item => new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Product.Price
                }).ToList()
            };

            // Add the order to the database
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            // Return the order ID
            return order.Id;
        }
    }
}
