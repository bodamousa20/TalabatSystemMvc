using TalabatSmartVillage.ViewModel.RestaurantViewModels;

namespace TalabatSmartVillage.Repositories.Interfaces
{
    public interface IRestaurantRepo
    {
        IEnumerable<RestaurantListViewModel> GetAll();
        RestaurantDetailsViewModel GetById(int id);
        void Create(RestaurantFormViewModel vm);
        void Update(RestaurantFormViewModel vm);
        RestaurantFormViewModel GetForEdit(int id);
        void Delete(int id);
    }
}
