namespace TalabatSmartVillage.ViewModel.MenuItemViewModels
{
    public class MenuItemCardViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public string? Image { get; set; }
        public string Category { get; set; }
    }
}
