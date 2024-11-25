using Microsoft.AspNetCore.Mvc;

namespace TranaWarePc.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public ApplicationUser User { get; set; }
    }
}
