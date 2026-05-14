using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TalabatSmartVillage.Models;

namespace TalabatSmartVillage.Configration
{
    public class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasMaxLength(255);

            builder.HasOne(p => p.Restaurant)
                    .WithMany(p => p.MenuItems)
                    .HasForeignKey(p => p.RestaurantId);

            builder.HasData(getMenuItemData());

        }
        private List<MenuItem> getMenuItemData()
        {
            return new List<MenuItem> { 

    // KFC (RestaurantId = 1)
    new MenuItem { Id = 1, RestaurantId = 1, Name = "Zinger Burger", Description = "Crispy spicy chicken burger", Price = 85.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1615486171448-4fc14234c9c7?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 2, RestaurantId = 1, Name = "Bucket Meal", Description = "8 pieces crispy chicken bucket", Price = 250.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1626645738196-c2a7c87a8f58?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 3, RestaurantId = 1, Name = "Coleslaw", Description = "Fresh creamy coleslaw side", Price = 20.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1512621776951-a57141f2eefd?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 4, RestaurantId = 1, Name = "Pepsi", Description = "Cold refreshing drink", Price = 15.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1622483767028-3f66f32aef97?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 5, RestaurantId = 1, Name = "Hot Wings", Description = "6 pieces spicy hot wings", Price = 75.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1626645738196-c2a7c87a8f58?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 6, RestaurantId = 1, Name = "Twister Wrap", Description = "Grilled chicken in a flour wrap", Price = 70.00m, IsAvailable = false, image = "https://images.unsplash.com/photo-1528735602780-2552fd46c7af?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 7, RestaurantId = 1, Name = "Mashed Potato", Description = "Creamy mashed potato with gravy", Price = 25.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1512621776951-a57141f2eefd?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 8, RestaurantId = 1, Name = "Chocolate Cake", Description = "Rich moist chocolate slice", Price = 35.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1578985545062-69928b1d9587?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 9, RestaurantId = 1, Name = "Family Meal", Description = "12 pieces with 2 sides and drinks", Price = 450.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1626645738196-c2a7c87a8f58?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 10, RestaurantId = 1, Name = "Corn on the Cob", Description = "Grilled sweet corn side", Price = 18.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1512621776951-a57141f2eefd?auto=format&fit=crop&w=800&q=80" },

    // McDonalds (RestaurantId = 2)
    new MenuItem { Id = 11, RestaurantId = 2, Name = "Big Mac", Description = "Classic double beef burger", Price = 95.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 12, RestaurantId = 2, Name = "McFries", Description = "Golden crispy french fries", Price = 30.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1576107232684-1279f390859f?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 13, RestaurantId = 2, Name = "McFlurry Oreo", Description = "Vanilla ice cream with Oreo", Price = 45.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1572490122747-3968b75cc699?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 14, RestaurantId = 2, Name = "Chicken McNuggets", Description = "10 pieces crispy nuggets", Price = 80.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1562967914-608f82629710?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 15, RestaurantId = 2, Name = "Quarter Pounder", Description = "Quarter pound beef patty burger", Price = 105.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 16, RestaurantId = 2, Name = "Apple Pie", Description = "Warm baked apple pie", Price = 20.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1578985545062-69928b1d9587?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 17, RestaurantId = 2, Name = "Filet-O-Fish", Description = "Crispy fish fillet burger", Price = 75.00m, IsAvailable = false, image = "https://images.unsplash.com/photo-1550547660-d9450f859349?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 18, RestaurantId = 2, Name = "Chocolate Shake", Description = "Thick creamy chocolate milkshake", Price = 40.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1572490122747-3968b75cc699?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 19, RestaurantId = 2, Name = "Happy Meal", Description = "Kids meal with toy", Price = 65.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 20, RestaurantId = 2, Name = "Double Cheeseburger", Description = "Double beef with double cheese", Price = 85.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?auto=format&fit=crop&w=800&q=80" },

    // Pizza Hut (RestaurantId = 3)
    new MenuItem { Id = 21, RestaurantId = 3, Name = "Margherita", Description = "Classic tomato and mozzarella", Price = 120.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1513104890138-7c749659a591?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 22, RestaurantId = 3, Name = "Pepperoni", Description = "Loaded spicy pepperoni pizza", Price = 145.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1628840042765-356cda07504e?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 23, RestaurantId = 3, Name = "BBQ Chicken", Description = "BBQ sauce with grilled chicken", Price = 155.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1565299624946-b28f40a0ae38?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 24, RestaurantId = 3, Name = "Garlic Bread", Description = "Toasted garlic butter bread", Price = 35.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1573140247632-f8fd74997d5c?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 25, RestaurantId = 3, Name = "Pasta Arrabiata", Description = "Spicy tomato pasta", Price = 90.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1551183053-bf91a1d81141?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 26, RestaurantId = 3, Name = "Cheesy Bites", Description = "Pizza with cheese stuffed crust", Price = 165.00m, IsAvailable = false, image = "https://images.unsplash.com/photo-1513104890138-7c749659a591?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 27, RestaurantId = 3, Name = "Chicken Wings", Description = "8 pieces BBQ chicken wings", Price = 95.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1565299585323-38d6b0865b47?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 28, RestaurantId = 3, Name = "Caesar Salad", Description = "Romaine lettuce with caesar dressing", Price = 65.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1512621776951-a57141f2eefd?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 29, RestaurantId = 3, Name = "Lava Cake", Description = "Warm chocolate lava cake", Price = 55.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1578985545062-69928b1d9587?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 30, RestaurantId = 3, Name = "Pepsi Can", Description = "330ml cold pepsi can", Price = 15.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1622483767028-3f66f32aef97?auto=format&fit=crop&w=800&q=80" },

    // Dominos (RestaurantId = 4)
    new MenuItem { Id = 31, RestaurantId = 4, Name = "ExtravaganZZa", Description = "Loaded with all toppings", Price = 175.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1513104890138-7c749659a591?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 32, RestaurantId = 4, Name = "MeatZZa", Description = "Triple meat loaded pizza", Price = 165.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1628840042765-356cda07504e?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 33, RestaurantId = 4, Name = "Veggie Feast", Description = "Fresh garden vegetables pizza", Price = 130.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1565299624946-b28f40a0ae38?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 34, RestaurantId = 4, Name = "Stuffed Crust", Description = "Cheese filled crust pizza", Price = 155.00m, IsAvailable = false, image = "https://images.unsplash.com/photo-1513104890138-7c749659a591?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 35, RestaurantId = 4, Name = "Chicken Kickers", Description = "10 pieces crispy chicken bites", Price = 85.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1562967914-608f82629710?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 36, RestaurantId = 4, Name = "Potato Wedges", Description = "Crispy seasoned potato wedges", Price = 40.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1576107232684-1279f390859f?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 37, RestaurantId = 4, Name = "Brownie", Description = "Warm chocolate brownie", Price = 45.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1578985545062-69928b1d9587?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 38, RestaurantId = 4, Name = "Diet Pepsi", Description = "330ml cold diet pepsi", Price = 15.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1622483767028-3f66f32aef97?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 39, RestaurantId = 4, Name = "Dips Pack", Description = "4 dipping sauces of your choice", Price = 20.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1472476443507-c7a5948772fc?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 40, RestaurantId = 4, Name = "Cheesy Garlic Bread", Description = "Garlic bread with melted cheese", Price = 45.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1573140247632-f8fd74997d5c?auto=format&fit=crop&w=800&q=80" },

    // Sushi King (RestaurantId = 5)
    new MenuItem { Id = 41, RestaurantId = 5, Name = "Salmon Roll", Description = "Fresh salmon with avocado", Price = 150.00m, IsAvailable = false, image = "https://images.unsplash.com/photo-1579871494447-9811cf80d66c?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 42, RestaurantId = 5, Name = "Tuna Sashimi", Description = "8 slices fresh tuna sashimi", Price = 180.00m, IsAvailable = false, image = "https://images.unsplash.com/photo-1583623025817-d180a2221d0a?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 43, RestaurantId = 5, Name = "Dragon Roll", Description = "Shrimp tempura topped with avocado", Price = 165.00m, IsAvailable = false, image = "https://images.unsplash.com/photo-1553621042-f6e147245754?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 44, RestaurantId = 5, Name = "Miso Soup", Description = "Traditional Japanese miso soup", Price = 35.00m, IsAvailable = false, image = "https://images.unsplash.com/photo-1547592180-85f173990554?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 45, RestaurantId = 5, Name = "Edamame", Description = "Steamed salted soybeans", Price = 40.00m, IsAvailable = false, image = "https://images.unsplash.com/photo-1512621776951-a57141f2eefd?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 46, RestaurantId = 5, Name = "California Roll", Description = "Crab, cucumber and avocado", Price = 120.00m, IsAvailable = false, image = "https://images.unsplash.com/photo-1579871494447-9811cf80d66c?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 47, RestaurantId = 5, Name = "Prawn Tempura", Description = "Crispy deep fried prawns", Price = 145.00m, IsAvailable = false, image = "https://images.unsplash.com/photo-1580894732444-8ecded7900cd?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 48, RestaurantId = 5, Name = "Gyoza", Description = "Pan fried Japanese dumplings", Price = 85.00m, IsAvailable = false, image = "https://images.unsplash.com/photo-1496116218417-1a781b1c416c?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 49, RestaurantId = 5, Name = "Green Tea Ice Cream", Description = "Matcha flavored ice cream", Price = 55.00m, IsAvailable = false, image = "https://images.unsplash.com/photo-1572490122747-3968b75cc699?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 50, RestaurantId = 5, Name = "Ramen", Description = "Rich pork broth noodle soup", Price = 130.00m, IsAvailable = false, image = "https://images.unsplash.com/photo-1557872943-16a5ac26437e?auto=format&fit=crop&w=800&q=80" },

    // Tokyo House (RestaurantId = 6)
    new MenuItem { Id = 51, RestaurantId = 6, Name = "Rainbow Roll", Description = "8 pieces colorful sushi roll", Price = 160.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1553621042-f6e147245754?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 52, RestaurantId = 6, Name = "Spicy Tuna Roll", Description = "Tuna with spicy mayo sauce", Price = 145.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1579871494447-9811cf80d66c?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 53, RestaurantId = 6, Name = "Chicken Teriyaki", Description = "Grilled chicken in teriyaki sauce", Price = 140.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1580894732444-8ecded7900cd?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 54, RestaurantId = 6, Name = "Shrimp Tempura Roll", Description = "Crispy shrimp in sushi roll", Price = 155.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1579871494447-9811cf80d66c?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 55, RestaurantId = 6, Name = "Mochi Ice Cream", Description = "Japanese rice cake with ice cream", Price = 65.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1572490122747-3968b75cc699?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 56, RestaurantId = 6, Name = "Yakitori", Description = "Grilled chicken skewers", Price = 95.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1528735602780-2552fd46c7af?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 57, RestaurantId = 6, Name = "Takoyaki", Description = "Japanese octopus balls", Price = 80.00m, IsAvailable = false, image = "https://images.unsplash.com/photo-1547592180-85f173990554?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 58, RestaurantId = 6, Name = "Udon Noodles", Description = "Thick wheat noodles in broth", Price = 110.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1557872943-16a5ac26437e?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 59, RestaurantId = 6, Name = "Matcha Latte", Description = "Hot Japanese green tea latte", Price = 45.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1515823662415-e0fac04ea553?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 60, RestaurantId = 6, Name = "Salmon Sashimi", Description = "6 slices fresh salmon sashimi", Price = 170.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1583623025817-d180a2221d0a?auto=format&fit=crop&w=800&q=80" },

    // Shake Shack (RestaurantId = 7)
    new MenuItem { Id = 61, RestaurantId = 7, Name = "ShackBurger", Description = "Cheeseburger with ShackSauce", Price = 130.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 62, RestaurantId = 7, Name = "SmokeShack", Description = "Bacon cheeseburger with cherry peppers", Price = 150.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 63, RestaurantId = 7, Name = "Shack Stack", Description = "Cheeseburger with crispy mushroom", Price = 170.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 64, RestaurantId = 7, Name = "Crinkle Cut Fries", Description = "Classic crinkle cut fries", Price = 45.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1576107232684-1279f390859f?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 65, RestaurantId = 7, Name = "Vanilla Shake", Description = "Hand spun vanilla milkshake", Price = 75.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1572490122747-3968b75cc699?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 66, RestaurantId = 7, Name = "Strawberry Shake", Description = "Hand spun strawberry milkshake", Price = 75.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1572490122747-3968b75cc699?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 67, RestaurantId = 7, Name = "Chicken Shack", Description = "Crispy chicken sandwich", Price = 120.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1615486171448-4fc14234c9c7?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 68, RestaurantId = 7, Name = "Cheese Fries", Description = "Crinkle fries with cheese sauce", Price = 60.00m, IsAvailable = false, image = "https://images.unsplash.com/photo-1576107232684-1279f390859f?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 69, RestaurantId = 7, Name = "Portobello Burger", Description = "Crispy portobello mushroom burger", Price = 125.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 70, RestaurantId = 7, Name = "Lemonade", Description = "Fresh squeezed lemonade", Price = 35.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1513558161293-cdaf765ed2fd?auto=format&fit=crop&w=800&q=80" },

    // Five Guys (RestaurantId = 8)
    new MenuItem { Id = 71, RestaurantId = 8, Name = "Five Guys Burger", Description = "Two beef patties all the way", Price = 155.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 72, RestaurantId = 8, Name = "Little Burger", Description = "Single beef patty burger", Price = 120.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 73, RestaurantId = 8, Name = "Cajun Fries", Description = "Seasoned fries with cajun spice", Price = 50.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1576107232684-1279f390859f?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 74, RestaurantId = 8, Name = "Bacon Burger", Description = "Beef patty with crispy bacon", Price = 165.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 75, RestaurantId = 8, Name = "Milkshake", Description = "Choose from 10 mix-in flavors", Price = 80.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1572490122747-3968b75cc699?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 76, RestaurantId = 8, Name = "Hot Dog", Description = "All beef kosher hot dog", Price = 90.00m, IsAvailable = false, image = "https://images.unsplash.com/photo-1612392062631-94dd858cba88?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 77, RestaurantId = 8, Name = "Grilled Cheese", Description = "Toasted bread with melted cheese", Price = 70.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1528735602780-2552fd46c7af?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 78, RestaurantId = 8, Name = "BLT Sandwich", Description = "Bacon lettuce and tomato sandwich", Price = 95.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1528735602780-2552fd46c7af?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 79, RestaurantId = 8, Name = "Veggie Sandwich", Description = "Grilled vegetables in a bun", Price = 85.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1528735602780-2552fd46c7af?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 80, RestaurantId = 8, Name = "Fountain Drink", Description = "Free refill soft drink", Price = 20.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1622483767028-3f66f32aef97?auto=format&fit=crop&w=800&q=80" },

    // Hardees (RestaurantId = 9)
    new MenuItem { Id = 81, RestaurantId = 9, Name = "Thickburger", Description = "Half pound Angus beef burger", Price = 135.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 82, RestaurantId = 9, Name = "Chicken Fillet", Description = "Crispy fried chicken sandwich", Price = 95.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1615486171448-4fc14234c9c7?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 83, RestaurantId = 9, Name = "Natural Cut Fries", Description = "Hand scooped natural cut fries", Price = 35.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1576107232684-1279f390859f?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 84, RestaurantId = 9, Name = "Loaded Fries", Description = "Fries with cheese and bacon", Price = 55.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1576107232684-1279f390859f?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 85, RestaurantId = 9, Name = "Mushroom Burger", Description = "Beef patty with mushroom sauce", Price = 125.00m, IsAvailable = false, image = "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 86, RestaurantId = 9, Name = "Onion Rings", Description = "Crispy battered onion rings", Price = 30.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1626645738196-c2a7c87a8f58?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 87, RestaurantId = 9, Name = "Breakfast Burrito", Description = "Eggs bacon and cheese in a wrap", Price = 75.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1528735602780-2552fd46c7af?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 88, RestaurantId = 9, Name = "Peach Shake", Description = "Fresh peach milkshake", Price = 55.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1572490122747-3968b75cc699?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 89, RestaurantId = 9, Name = "Double Thickburger", Description = "Double half pound Angus burger", Price = 185.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 90, RestaurantId = 9, Name = "Cole Slaw", Description = "Classic creamy coleslaw", Price = 20.00m, IsAvailable = true, image = "https://images.unsplash.com/photo-1512621776951-a57141f2eefd?auto=format&fit=crop&w=800&q=80" },

    // Popeyes (RestaurantId = 10)
    new MenuItem { Id = 91, RestaurantId = 10, Name = "Chicken Sandwich", Description = "Crispy buttermilk chicken", Price = 110.00m, IsAvailable = false, image = "https://images.unsplash.com/photo-1615486171448-4fc14234c9c7?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 92, RestaurantId = 10, Name = "3 Piece Chicken", Description = "3 pieces spicy or mild chicken", Price = 125.00m, IsAvailable = false, image = "https://images.unsplash.com/photo-1626645738196-c2a7c87a8f58?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 93, RestaurantId = 10, Name = "Red Beans Rice", Description = "Classic Louisiana red beans rice", Price = 40.00m, IsAvailable = false, image = "https://images.unsplash.com/photo-1512621776951-a57141f2eefd?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 94, RestaurantId = 10, Name = "Biscuit", Description = "Buttermilk flaky biscuit", Price = 15.00m, IsAvailable = false, image = "https://images.unsplash.com/photo-1578985545062-69928b1d9587?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 95, RestaurantId = 10, Name = "Mac and Cheese", Description = "Creamy macaroni and cheese", Price = 45.00m, IsAvailable = false, image = "https://images.unsplash.com/photo-1551183053-bf91a1d81141?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 96, RestaurantId = 10, Name = "Mashed Potatoes", Description = "Creamy mashed potatoes with gravy", Price = 30.00m, IsAvailable = false, image = "https://images.unsplash.com/photo-1512621776951-a57141f2eefd?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 97, RestaurantId = 10, Name = "Chicken Tenders", Description = "5 pieces chicken tenders", Price = 100.00m, IsAvailable = false, image = "https://images.unsplash.com/photo-1562967914-608f82629710?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 98, RestaurantId = 10, Name = "Cajun Fries", Description = "Seasoned Cajun spiced fries", Price = 35.00m, IsAvailable = false, image = "https://images.unsplash.com/photo-1576107232684-1279f390859f?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 99, RestaurantId = 10, Name = "Strawberry Lemonade", Description = "Fresh strawberry lemonade", Price = 40.00m, IsAvailable = false, image = "https://images.unsplash.com/photo-1513558161293-cdaf765ed2fd?auto=format&fit=crop&w=800&q=80" },
    new MenuItem { Id = 100, RestaurantId = 10, Name = "Spicy Tenders", Description = "Extra spicy chicken tenders", Price = 110.00m, IsAvailable = false, image = "https://images.unsplash.com/photo-1562967914-608f82629710?auto=format&fit=crop&w=800&q=80" }


            };


        }
    }

}

