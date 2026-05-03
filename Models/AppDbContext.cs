using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TalabatSmartVillage.Configration;

namespace TalabatSmartVillage.Models
{
    public class AppDbContext:IdentityDbContext<AppUser>
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
            modelBuilder.ApplyConfiguration(new  RestaurantConfiguration ());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());


        }
    }
}
