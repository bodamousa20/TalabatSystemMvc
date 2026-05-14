using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TalabatSmartVillage.Models;

namespace TalabatSmartVillage.Configration
{
   
    public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasMaxLength(255);
            builder.Property(p => p.Address).IsRequired().HasMaxLength(120);

            builder.HasOne(p => p.Category)
                    .WithMany(p => p.Restaurants)
                    .HasForeignKey(p => p.CategoryId);


            builder.HasData(AddRestrantData());
        }

        private List<Restaurant> AddRestrantData()
        {
            return new List<Restaurant> {

            new Restaurant { Id = 1, CategoryId = 1, Name = "KFC", Address = "Cairo, Nasr City", IsOpen = true },
            new Restaurant { Id = 2, CategoryId = 1, Name = "McDonalds", Address = "Giza, Mohandessin", IsOpen = true },
            new Restaurant { Id = 3, CategoryId = 2, Name = "Pizza Hut", Address = "Alexandria, Smouha", IsOpen = true },
            new Restaurant { Id = 4, CategoryId = 2, Name = "Dominos", Address = "Cairo, Maadi", IsOpen = true },
            new Restaurant { Id = 5, CategoryId = 3, Name = "Sushi King", Address = "Cairo, Zamalek", IsOpen = false },
            new Restaurant { Id = 6, CategoryId = 3, Name = "Tokyo House", Address = "Giza, Sheikh Zayed", IsOpen = true },
            new Restaurant { Id = 7, CategoryId = 4, Name = "Shake Shack", Address = "Cairo, New Cairo", IsOpen = true },
            new Restaurant { Id = 8, CategoryId = 4, Name = "Five Guys", Address = "Cairo, Heliopolis", IsOpen = true },
            new Restaurant { Id = 9, CategoryId = 5, Name = "Hardees", Address = "Giza, Dokki", IsOpen = true },
            new Restaurant { Id = 10, CategoryId = 5, Name = "Popeyes", Address = "Cairo, Nasr City", IsOpen = false },
            new Restaurant { Id = 11, CategoryId = 6, Name = "Fish Market", Address = "Alexandria, Corniche", IsOpen = true },
            new Restaurant { Id = 12, CategoryId = 6, Name = "Sea Breeze", Address = "Cairo, Maadi", IsOpen = true },
            new Restaurant { Id = 13, CategoryId = 7, Name = "Cinnabon", Address = "Cairo, City Stars", IsOpen = true },
            new Restaurant { Id = 14, CategoryId = 7, Name = "Baskin Robbins", Address = "Giza, Mohandessin", IsOpen = true },
            new Restaurant { Id = 15, CategoryId = 8, Name = "Salad Bar", Address = "Cairo, New Cairo", IsOpen = true }

            };
         
        }
    }

}
