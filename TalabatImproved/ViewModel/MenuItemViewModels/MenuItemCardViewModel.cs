namespace TalabatSmartVillage.ViewModel.MenuItemViewModels
{
    public class MenuItemCardViewModel
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }   // Added - was missing, caused the bug
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public string? Image { get; set; }
        public string Category { get; set; } = string.Empty;
    }
}
