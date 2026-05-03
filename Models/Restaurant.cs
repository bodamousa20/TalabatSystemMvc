using System.ComponentModel.DataAnnotations;

namespace TalabatSmartVillage.Models
{
    public class Restaurant
    {
      
        public int Id { set; get; }

        public string Name { set; get; }

        public string Address { set; get; }

        public bool IsOpen { set; get; }

        public int CategoryId { set; get; }
 

        //Navigation Prop
        public Category Category { set; get; }

        public ICollection<MenuItem> MenuItems { set; get; } = new List<MenuItem>();
        public ICollection<Order> Orders { set; get; } = new List<Order>();

    }

}
