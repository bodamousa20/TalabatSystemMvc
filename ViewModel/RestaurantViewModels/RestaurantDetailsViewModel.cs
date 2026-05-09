using TalabatSmartVillage.ViewModel.MenuItemViewModels;

namespace TalabatSmartVillage.ViewModel.RestaurantViewModels
{
    public class RestaurantDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string Address { get; set; }
        public bool IsOpen { get; set; }
        public IEnumerable<MenuItemListViewModel> MenuItems { get; set; }
    }
}
