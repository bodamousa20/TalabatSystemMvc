using System.ComponentModel.DataAnnotations;
using TalabatSmartVillage.Auth;

namespace TalabatSmartVillage.Models
{
    public class Order
    {
       
        public int Id { set; get; }

        public string UserId { set; get; }
        public int RestaurantId { set; get; }

        public AppUser User { set; get; }
        public Restaurant Restaurant { set; get; }


        public OrderStatus Status { set; get; }

        public decimal TotalOrderPrice { set; get; }

        public DateTime PlacedAt { set; get; }

        public ICollection<OrderItem> OrderItems { set; get; } = new List<OrderItem>();

    }
    public enum OrderStatus
    {
        PENDING,CONFIRMED,DELIVERED,CANCELLED
    } 
    public class OrderItem
    {
        
        public int Id { set; get; }

        public int OrderId { set; get; }
        public int MenuItemId { set; get; }

        public Order order { set; get; }
        public MenuItem menuItem { set; get; }
        public int Quantity { set; get; }
        public decimal UnitPrice { set; get; }
    }
}
