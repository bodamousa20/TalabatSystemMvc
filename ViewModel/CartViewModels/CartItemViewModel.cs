namespace TalabatSmartVillage.ViewModel.CartViewModels
{
    public class CartItemViewModel
    {
        public int MenuItemId { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal LineTotal => UnitPrice * Quantity;
    }
}
