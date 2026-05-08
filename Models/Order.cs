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
}
