using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TalabatSmartVillage.Auth;
using TalabatSmartVillage.Configration;
using TalabatSmartVillage.Dtos;

namespace TalabatSmartVillage.Models
{
    public class AppDbContext:IdentityDbContext<AppUser,AppRole,string>
    {

        public DbSet<Category> category { set; get; }
        public DbSet<Restaurant> restaurant { set; get; }
        public DbSet<MenuItem> MenuItem { set; get; }
        public DbSet<Order> Order { set; get; }
        public DbSet<OrderItem> OrderItem { set; get; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.ApplyConfiguration(new MenuItemConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemConfigration());
            modelBuilder.ApplyConfiguration(new  RestaurantConfiguration ());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());


        }
        public DbSet<TalabatSmartVillage.Dtos.RegisterViewModel> RegisterDto { get; set; } = default!;
        public DbSet<TalabatSmartVillage.Dtos.LoginViewModel> LoginDto { get; set; } = default!;
    }
}
