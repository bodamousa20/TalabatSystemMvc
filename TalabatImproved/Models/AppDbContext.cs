using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TalabatSmartVillage.Auth;
using TalabatSmartVillage.Configration;

namespace TalabatSmartVillage.Models
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public DbSet<Category> category { get; set; }
        public DbSet<Restaurant> restaurant { get; set; }
        public DbSet<MenuItem> MenuItem { get; set; }
        public DbSet<Order> Order { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new MenuItemConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemConfigration());
            modelBuilder.ApplyConfiguration(new RestaurantConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            const string adminRoleId = "A78adjdnmjj5214-03945fv43mf";
            const string userRoleId  = "bkdd8ad52mjj5214-03945fv43ds";
            const string adminUserId = "adminsIdFakerIdes125d2E23";

            modelBuilder.Entity<AppRole>().HasData(
                new AppRole
                {
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId,
                    Name = AppRoles.ADMIN,
                    NormalizedName = AppRoles.ADMIN
                },
                new AppRole
                {
                    Id = userRoleId,
                    ConcurrencyStamp = userRoleId,
                    Name = AppRoles.USER,
                    NormalizedName = AppRoles.USER
                }
            );

            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminUserId,
                Email = "admin@talabat.com",
                NormalizedEmail = "ADMIN@TALABAT.COM",
                UserName = "admin@talabat.com",
                NormalizedUserName = "ADMIN@TALABAT.COM",
                EmailConfirmed = true,
                SecurityStamp = "ff917ecc-c7f6-446a-a286-475b554d5fc0",
                ConcurrencyStamp = "ae56e2eb-a436-4980-adf5-14e3ec424a83",
                Address = "Admin HQ",
                FullName = "System Admin",
                CreatedAt = new DateTime(2024, 1, 1),
                postalcode = 0,
                // Password: Admin@123!
                PasswordHash = "AQAAAAIAAYagAAAAEKCc38T78doP4i8xDcHSarN9K8s9boaQ/tqiUNFdI+vO+jTenMkuJmuCCfNgnQP0NQ=="
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                UserId = adminUserId,
                RoleId = adminRoleId
            });
        }
    }
}
