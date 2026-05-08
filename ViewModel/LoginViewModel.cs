using System.ComponentModel.DataAnnotations;

namespace TalabatSmartVillage.Dtos
{
    public class LoginViewModel
    {
        [Key]
        public int id { set; get; }
        [Required(ErrorMessage = ("The Email is Required"))]
        public string Email { set; get; }
        [Required(ErrorMessage = ("The password is Required"))]
        public string password { set; get; }
    }
}