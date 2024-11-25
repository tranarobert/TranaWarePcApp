﻿namespace PawWebApp.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }

        public PcComponent Product {  get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
