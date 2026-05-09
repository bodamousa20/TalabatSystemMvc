namespace TalabatSmartVillage.Models
{
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
