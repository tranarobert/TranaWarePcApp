using Newtonsoft.Json;
using TranaWarePcApp.Models;
using TranaWarePcApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TranaWarePcApp.Services;

namespace TranaWarePcApp.Services
{
    public class CartService : ICartService
    {
        private readonly TranaWareContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPcComponentService _pcComponentService;

        public CartService(TranaWareContext context, IHttpContextAccessor httpContextAccessor, IPcComponentService pcComponentService)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _pcComponentService = pcComponentService;
        }

        private Cart GetCartFromSession()
        {
            var session = _httpContextAccessor.HttpContext.Session;
            var cartJson = session.GetString("Cart");
            return cartJson != null ? JsonConvert.DeserializeObject<Cart>(cartJson) : new Cart();
        }

        private void SaveCartToSession(Cart cart)
        {
            var session = _httpContextAccessor.HttpContext.Session;
            var cartJson = JsonConvert.SerializeObject(cart);
            session.SetString("Cart", cartJson);
        }

        public async Task AddToCartAsync(int productId, int quantity)
        {
            var cart = GetCartFromSession();
            var product = await _pcComponentService.GetComponentByIdAsync(productId);
            var cartItem = cart.Items.FirstOrDefault(i => i.ProductId == productId);

            if (cartItem != null)
            {
                cartItem.Quantity += quantity;
            }
            else
            {
                cart.Items.Add(new CartItem
                {
                    ProductId = productId,
                    Quantity = quantity,
                    Price = product.Price,
                    ProductName = product.Name,
                    ProductImage = product.PhotoFileName
                });
            }

            SaveCartToSession(cart);
        }

        public void RemoveFromCart(int productId)
        {
            var cart = GetCartFromSession();
            var cartItem = cart.Items.FirstOrDefault(i => i.ProductId == productId);

            if (cartItem != null)
            {
                cart.Items.Remove(cartItem);
            }

            SaveCartToSession(cart);
        }

        public void ClearCart()
        {
            var cart = new Cart();
            SaveCartToSession(cart);
        }

        public Cart GetCart()
        {
            return GetCartFromSession();
        }

        public async Task<List<CartItem>> GetCartItemsAsync(string userId)
        {
            return await _context.CartItems
                .Include(ci => ci.Product) // Ensure products are included
                .Where(ci => ci.UserId == userId)
                .ToListAsync();
        }

        public async Task ClearCartAsync(string userId)
        {
            var cartItems = await _context.CartItems
                .Where(ci => ci.UserId == userId)
                .ToListAsync();

            _context.CartItems.RemoveRange(cartItems);
            await _context.SaveChangesAsync();
        }
    }
}
