using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TalabatSmartVillage.Models;

namespace TalabatSmartVillage.Configration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasMaxLength(255);

            builder.HasData(getCategoryData());

        }
        private List<Category> getCategoryData()
        {
            return new List<Category>{

                            new Category { Id = 1, Name = "Fast Food" },
                            new Category { Id = 2, Name = "Pizza" },
                            new Category { Id = 3, Name = "Sushi" },
                            new Category { Id = 4, Name = "Burgers" },
                            new Category { Id = 5, Name = "Chicken" },
                            new Category { Id = 6, Name = "Seafood" },
                            new Category { Id = 7, Name = "Desserts" },
                            new Category { Id = 8, Name = "Healthy" }
            };


        }
    }

}

