using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TalabatSmartVillage.Auth;
using TalabatSmartVillage.Models;
using TalabatSmartVillage.Repositories.Interfaces;
using TalabatSmartVillage.ViewModel.AdminViewModels;

namespace TalabatSmartVillage.Controllers
{
    [Authorize(Roles = AppRoles.ADMIN)]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }



        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
            var model = await _adminService.GetDashboardAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Orders()
        {
            var orders = await _adminService.GetOrdersAsync();
            return View(orders);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateOrderStatus(int orderId, OrderStatus status)
        {
            var found = await _adminService.UpdateOrderStatusAsync(orderId, status);
            if (!found)
                return NotFound();

            TempData["Success"] = $"Order #{orderId} status updated.";
            return RedirectToAction(nameof(Orders));
        }





    }
}
