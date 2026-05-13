using System.ComponentModel.DataAnnotations;

namespace TalabatSmartVillage.Models
{
    public class MenuItem
    {
   
        public int Id { set; get; }

        public string Name { set; get; }

        public string Description { set; get; }

        public decimal Price { set; get; }

        public bool IsAvailable { set; get; }

        public string? image { set; get; }

        public int RestaurantId { set; get; }

        public Restaurant Restaurant { set; get; }

    }

}
