namespace TalabatSmartVillage.ViewModel.OrderViewModels
{
    public class OrderItemViewModel
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal => UnitPrice * Quantity;
    }
}
