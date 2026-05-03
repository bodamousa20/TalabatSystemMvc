using System.ComponentModel.DataAnnotations;

namespace TalabatSmartVillage.Models
{
    public class Category
    {
      
        public int Id { set; get; }

        public string Name { set; get; }

        public ICollection<Restaurant> Restaurants { set; get; } = new List<Restaurant>();
    }
}
