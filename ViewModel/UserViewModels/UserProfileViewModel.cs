using System.ComponentModel.DataAnnotations;

namespace TalabatSmartVillage.ViewModel.UserViewModels
{
    public class UserProfileViewModel
    {
        [Required(ErrorMessage = "Full name is required.")]
        [MaxLength(50, ErrorMessage = "Full name must not exceed 50 characters.")]
        public string FullName { get; set; }

        public string Email { get; set; }

        [Phone(ErrorMessage = "Enter a valid phone number.")]
        [MaxLength(15, ErrorMessage = "Phone number must not exceed 15 characters.")]
        public string? PhoneNumber { get; set; }

        [MaxLength(200, ErrorMessage = "Address must not exceed 200 characters.")]
        public string? Address { get; set; }

        [Range(0, 999999, ErrorMessage = "Postal code must be valid.")]
        public int? PostalCode { get; set; }

        public DateTime CreatedAt { get; set; }
        public string Roles { get; set; }
    }
}
