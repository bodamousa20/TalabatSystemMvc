using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TalabatSmartVillage.Auth;
using TalabatSmartVillage.Configration;
using TalabatSmartVillage.Dtos;
using static Day8_Assigment.Controllers.AccountController;

namespace TalabatSmartVillage.Models
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {

        public DbSet<Category> category { set; get; }
        public DbSet<Restaurant> restaurant { set; get; }
        public DbSet<MenuItem> MenuItem { set; get; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.ApplyConfiguration(new MenuItemConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemConfigration());
            modelBuilder.ApplyConfiguration(new RestaurantConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            var AdminRoleId = "A78adjdnmjj5214-03945fv%43mf";
            var UserRoleId = "bkdd8ad52mjj5214-03945fv%43ds";
            var AdminUserId = "adminsIdFakerIdes125d$2$@E@23";

            // --- Seed Roles using AppRole ---
            var adminRole = new AppRole
            {
                Id = AdminRoleId,
                ConcurrencyStamp = AdminRoleId,
                Name = AccountsRoles.ADMIN.ToString(),
                NormalizedName = AccountsRoles.ADMIN.ToString().ToUpper()
            };

            var userRole = new AppRole
            {
                Id = UserRoleId,
                ConcurrencyStamp = UserRoleId,
                Name = AccountsRoles.USER.ToString(),
                NormalizedName = AccountsRoles.USER.ToString().ToUpper()
            };

            modelBuilder.Entity<AppRole>().HasData(adminRole, userRole);




            var adminUser = new AppUser
            {
                Id = "adminsIdFakerIdes125d$2$@E@23",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                EmailConfirmed = true,
                SecurityStamp = "ff917ecc-c7f6-446a-a286-475b554d5fc0",
                ConcurrencyStamp = "ae56e2eb-a436-4980-adf5-14e3ec424a83",
                Address = "Admin Address",
                FullName = "Admin",
                CreatedAt = new DateTime(2024, 1, 1),
                postalcode = 0,

                // ✅ Hardcoded hash — copy this exactly (password is Admin@123!)
                PasswordHash = "AQAAAAIAAYagAAAAEKCc38T78doP4i8xDcHSarN9K8s9boaQ/tqiUNFdI+vO+jTenMkuJmuCCfNgnQP0NQ=="
            };


            modelBuilder.Entity<AppUser>().HasData(adminUser);

            // --- Seed Admin Role Assignment ---
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                UserId = AdminUserId,
                RoleId = AdminRoleId
            });
        }
    }
}
