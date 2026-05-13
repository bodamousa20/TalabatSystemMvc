namespace TalabatSmartVillage.ViewModel.OrderViewModels
{
    public class OrderSummaryViewModel
    {
        public int Id { get; set; }
        public DateTime PlacedAt { get; set; }
        public decimal TotalOrderPrice { get; set; }
        public string Status { get; set; }
        public string StatusBadgeClass { get; set; }
        public IReadOnlyList<OrderItemViewModel> Items { get; set; } = new List<OrderItemViewModel>();
    }
}
