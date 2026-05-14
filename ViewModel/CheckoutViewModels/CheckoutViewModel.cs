using System.ComponentModel.DataAnnotations;
using TalabatSmartVillage.ViewModel.CartViewModels;

namespace TalabatSmartVillage.ViewModel.CheckoutViewModels
{
    public class CheckoutViewModel
    {
        // Delivery info
        [Required(ErrorMessage = "Full name is required.")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Enter a valid phone number.")]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Delivery address is required.")]
        [Display(Name = "Delivery Address")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; } = string.Empty;

        // Payment info (fake for testing)
        [Required(ErrorMessage = "Card holder name is required.")]
        [Display(Name = "Card Holder Name")]
        public string CardHolderName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Card number is required.")]
        [Display(Name = "Card Number")]
        [RegularExpression(@"^\d{16}$", ErrorMessage = "Card number must be 16 digits.")]
        public string CardNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Expiry date is required.")]
        [Display(Name = "Expiry (MM/YY)")]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/\d{2}$", ErrorMessage = "Format must be MM/YY.")]
        public string ExpiryDate { get; set; } = string.Empty;

        [Required(ErrorMessage = "CVV is required.")]
        [RegularExpression(@"^\d{3,4}$", ErrorMessage = "CVV must be 3 or 4 digits.")]
        public string CVV { get; set; } = string.Empty;

        // Read-only cart summary (filled from session)
        public List<CartItemViewModel> CartItems { get; set; } = new();
        public decimal Total => CartItems.Sum(x => x.LineTotal);
        public int RestaurantId { get; set; }
    }
}
