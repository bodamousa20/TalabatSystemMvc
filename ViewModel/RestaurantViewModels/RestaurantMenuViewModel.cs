using TalabatSmartVillage.ViewModel.MenuItemViewModels;

namespace TalabatSmartVillage.ViewModel.RestaurantViewModels
{
    public class RestaurantMenuViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string Address { get; set; }
        public bool IsOpen { get; set; }
        public string Description { get; set; }
        public string? BannerImageUrl { get; set; }
        public string? SearchTerm { get; set; }
        public string? SelectedCategory { get; set; }
        public IReadOnlyList<MenuCategoryFilterViewModel> Categories { get; set; } = new List<MenuCategoryFilterViewModel>();
        public IReadOnlyList<MenuItemCardViewModel> MenuItems { get; set; } = new List<MenuItemCardViewModel>();
    }
}
