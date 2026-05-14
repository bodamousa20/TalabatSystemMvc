using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using TalabatSmartVillage.Models;

namespace TalabatSmartVillage.Auth
{
    public class AppUser:IdentityUser
    {

     public string? FullName { set; get; }
     public string?Address { set; get; }
     public int postalcode { set; get; }
     public DateTime CreatedAt { set; get; }
     public ICollection<Order> ? Orders { set; get; }
    }
}
