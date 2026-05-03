using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TalabatSmartVillage.Models
{
    public class AppUser:IdentityUser
    {

     public string FullName { set; get; }

     public DateTime CreatedAt { set; get; }
     public ICollection<Order> Orders { set; get; }
    }
}
