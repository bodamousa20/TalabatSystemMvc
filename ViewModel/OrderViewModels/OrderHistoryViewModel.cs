namespace TalabatSmartVillage.ViewModel.OrderViewModels
{
    public class OrderHistoryViewModel
    {
        public IReadOnlyList<OrderSummaryViewModel> Orders { get; set; } = new List<OrderSummaryViewModel>();
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalOrders { get; set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
    }
}
