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

                            new Category { Id = 1, Name = "Fast Food" , Description = "Quick and easy meals" },
                            new Category { Id = 2, Name = "Pizza" , Description = "Cheesy and delicious" },
                            new Category { Id = 3, Name = "Sushi" , Description = "Japanese delicacy" },
                            new Category { Id = 4, Name = "Burgers" , Description = "Juicy and filling" },
                            new Category { Id = 5, Name = "Chicken" , Description = "Tender and tasty" },
                            new Category { Id = 6, Name = "Seafood" , Description = "Fresh from the ocean" },
                            new Category { Id = 7, Name = "Desserts" , Description = "Sweet and indulgent" },
                            new Category { Id = 8, Name = "Healthy" , Description = "Nutritious and balanced" }
            };


        }
    }

}

