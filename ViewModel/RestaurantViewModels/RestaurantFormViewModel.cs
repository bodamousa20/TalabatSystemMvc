using Microsoft.AspNetCore.Mvc.Rendering;

namespace TalabatSmartVillage.ViewModel.RestaurantViewModels
{
    public class RestaurantFormViewModel
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Address { get; set; }
        public bool IsOpen { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
