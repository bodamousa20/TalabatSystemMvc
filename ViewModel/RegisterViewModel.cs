using System.ComponentModel.DataAnnotations;

namespace TalabatSmartVillage.Dtos
{
    public class RegisterViewModel
    {
        [Key]
        public int id { set; get; }

        [Required(ErrorMessage =("The fullname is Required"))]
        [MaxLength(50,ErrorMessage ="The fullname Must Not exceed 50 charcater")]
        public string FullName { set; get; }

        [Required(ErrorMessage = ("The username is Required"))]
        [MaxLength(20, ErrorMessage = "The username Must Not exceed 20 charcater")]
        public string username { set; get; }

        [Required(ErrorMessage = ("The phone is Required"))]
        [MaxLength(11, ErrorMessage = "The phone Must Not exceed 11 Number")]
        [MinLength(11, ErrorMessage = "The phone Must Not exceed 11 Number")]
        public string phone { set; get; }

        [Required(ErrorMessage = ("The Address is Required"))]
        public string Address { set; get; }

        [Required(ErrorMessage = ("The Postal Code is Required"))]
        public int postalCode { set; get; }

        [Required(ErrorMessage = ("The Email is Required"))]
        [EmailAddress]
        //[Unique]
        public string Email { set; get; }

        [Required(ErrorMessage =("The password is required"))]
        public string password { set; get; }
    }
}