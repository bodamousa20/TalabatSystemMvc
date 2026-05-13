using System.ComponentModel.DataAnnotations;

namespace TalabatSmartVillage.Controllers
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Full name is required.")]
        [MaxLength(50, ErrorMessage = "Full name must not exceed 50 characters.")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Enter a valid phone number.")]
        [MaxLength(15, ErrorMessage = "Phone number must not exceed 15 digits.")]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address is required.")]
        [MaxLength(200, ErrorMessage = "Address must not exceed 200 characters.")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Postal code is required.")]
        [Range(1, 999999, ErrorMessage = "Enter a valid postal code.")]
        [Display(Name = "Postal Code")]
        public int PostalCode { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Enter a valid email address.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please confirm your password.")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
