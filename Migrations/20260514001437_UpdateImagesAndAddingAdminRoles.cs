using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TalabatSmartVillage.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImagesAndAddingAdminRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    postalcode = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "restaurant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    IsOpen = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_restaurant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_restaurant_category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RestaurantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItem_restaurant_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "restaurant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RestaurantId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TotalOrderPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PlacedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_restaurant_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "restaurant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    MenuItemId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_MenuItem_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Quick and easy meals", "Fast Food" },
                    { 2, "Cheesy and delicious", "Pizza" },
                    { 3, "Japanese delicacy", "Sushi" },
                    { 4, "Juicy and filling", "Burgers" },
                    { 5, "Tender and tasty", "Chicken" },
                    { 6, "Fresh from the ocean", "Seafood" },
                    { 7, "Sweet and indulgent", "Desserts" },
                    { 8, "Nutritious and balanced", "Healthy" }
                });

            migrationBuilder.InsertData(
                table: "restaurant",
                columns: new[] { "Id", "Address", "CategoryId", "IsOpen", "Name" },
                values: new object[,]
                {
                    { 1, "Cairo, Nasr City", 1, true, "KFC" },
                    { 2, "Giza, Mohandessin", 1, true, "McDonalds" },
                    { 3, "Alexandria, Smouha", 2, true, "Pizza Hut" },
                    { 4, "Cairo, Maadi", 2, true, "Dominos" },
                    { 5, "Cairo, Zamalek", 3, false, "Sushi King" },
                    { 6, "Giza, Sheikh Zayed", 3, true, "Tokyo House" },
                    { 7, "Cairo, New Cairo", 4, true, "Shake Shack" },
                    { 8, "Cairo, Heliopolis", 4, true, "Five Guys" },
                    { 9, "Giza, Dokki", 5, true, "Hardees" },
                    { 10, "Cairo, Nasr City", 5, false, "Popeyes" },
                    { 11, "Alexandria, Corniche", 6, true, "Fish Market" },
                    { 12, "Cairo, Maadi", 6, true, "Sea Breeze" },
                    { 13, "Cairo, City Stars", 7, true, "Cinnabon" },
                    { 14, "Giza, Mohandessin", 7, true, "Baskin Robbins" },
                    { 15, "Cairo, New Cairo", 8, true, "Salad Bar" }
                });

            migrationBuilder.InsertData(
                table: "MenuItem",
                columns: new[] { "Id", "Description", "IsAvailable", "Name", "Price", "RestaurantId", "image" },
                values: new object[,]
                {
                    { 1, "Crispy spicy chicken burger", true, "Zinger Burger", 85.00m, 1, "https://images.unsplash.com/photo-1615486171448-4fc14234c9c7?auto=format&fit=crop&w=800&q=80" },
                    { 2, "8 pieces crispy chicken bucket", true, "Bucket Meal", 250.00m, 1, "https://images.unsplash.com/photo-1626645738196-c2a7c87a8f58?auto=format&fit=crop&w=800&q=80" },
                    { 3, "Fresh creamy coleslaw side", true, "Coleslaw", 20.00m, 1, "https://images.unsplash.com/photo-1512621776951-a57141f2eefd?auto=format&fit=crop&w=800&q=80" },
                    { 4, "Cold refreshing drink", true, "Pepsi", 15.00m, 1, "https://images.unsplash.com/photo-1622483767028-3f66f32aef97?auto=format&fit=crop&w=800&q=80" },
                    { 5, "6 pieces spicy hot wings", true, "Hot Wings", 75.00m, 1, "https://images.unsplash.com/photo-1626645738196-c2a7c87a8f58?auto=format&fit=crop&w=800&q=80" },
                    { 6, "Grilled chicken in a flour wrap", false, "Twister Wrap", 70.00m, 1, "https://images.unsplash.com/photo-1528735602780-2552fd46c7af?auto=format&fit=crop&w=800&q=80" },
                    { 7, "Creamy mashed potato with gravy", true, "Mashed Potato", 25.00m, 1, "https://images.unsplash.com/photo-1512621776951-a57141f2eefd?auto=format&fit=crop&w=800&q=80" },
                    { 8, "Rich moist chocolate slice", true, "Chocolate Cake", 35.00m, 1, "https://images.unsplash.com/photo-1578985545062-69928b1d9587?auto=format&fit=crop&w=800&q=80" },
                    { 9, "12 pieces with 2 sides and drinks", true, "Family Meal", 450.00m, 1, "https://images.unsplash.com/photo-1626645738196-c2a7c87a8f58?auto=format&fit=crop&w=800&q=80" },
                    { 10, "Grilled sweet corn side", true, "Corn on the Cob", 18.00m, 1, "https://images.unsplash.com/photo-1512621776951-a57141f2eefd?auto=format&fit=crop&w=800&q=80" },
                    { 11, "Classic double beef burger", true, "Big Mac", 95.00m, 2, "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?auto=format&fit=crop&w=800&q=80" },
                    { 12, "Golden crispy french fries", true, "McFries", 30.00m, 2, "https://images.unsplash.com/photo-1576107232684-1279f390859f?auto=format&fit=crop&w=800&q=80" },
                    { 13, "Vanilla ice cream with Oreo", true, "McFlurry Oreo", 45.00m, 2, "https://images.unsplash.com/photo-1572490122747-3968b75cc699?auto=format&fit=crop&w=800&q=80" },
                    { 14, "10 pieces crispy nuggets", true, "Chicken McNuggets", 80.00m, 2, "https://images.unsplash.com/photo-1562967914-608f82629710?auto=format&fit=crop&w=800&q=80" },
                    { 15, "Quarter pound beef patty burger", true, "Quarter Pounder", 105.00m, 2, "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?auto=format&fit=crop&w=800&q=80" },
                    { 16, "Warm baked apple pie", true, "Apple Pie", 20.00m, 2, "https://images.unsplash.com/photo-1578985545062-69928b1d9587?auto=format&fit=crop&w=800&q=80" },
                    { 17, "Crispy fish fillet burger", false, "Filet-O-Fish", 75.00m, 2, "https://images.unsplash.com/photo-1550547660-d9450f859349?auto=format&fit=crop&w=800&q=80" },
                    { 18, "Thick creamy chocolate milkshake", true, "Chocolate Shake", 40.00m, 2, "https://images.unsplash.com/photo-1572490122747-3968b75cc699?auto=format&fit=crop&w=800&q=80" },
                    { 19, "Kids meal with toy", true, "Happy Meal", 65.00m, 2, "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?auto=format&fit=crop&w=800&q=80" },
                    { 20, "Double beef with double cheese", true, "Double Cheeseburger", 85.00m, 2, "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?auto=format&fit=crop&w=800&q=80" },
                    { 21, "Classic tomato and mozzarella", true, "Margherita", 120.00m, 3, "https://images.unsplash.com/photo-1513104890138-7c749659a591?auto=format&fit=crop&w=800&q=80" },
                    { 22, "Loaded spicy pepperoni pizza", true, "Pepperoni", 145.00m, 3, "https://images.unsplash.com/photo-1628840042765-356cda07504e?auto=format&fit=crop&w=800&q=80" },
                    { 23, "BBQ sauce with grilled chicken", true, "BBQ Chicken", 155.00m, 3, "https://images.unsplash.com/photo-1565299624946-b28f40a0ae38?auto=format&fit=crop&w=800&q=80" },
                    { 24, "Toasted garlic butter bread", true, "Garlic Bread", 35.00m, 3, "https://images.unsplash.com/photo-1573140247632-f8fd74997d5c?auto=format&fit=crop&w=800&q=80" },
                    { 25, "Spicy tomato pasta", true, "Pasta Arrabiata", 90.00m, 3, "https://images.unsplash.com/photo-1551183053-bf91a1d81141?auto=format&fit=crop&w=800&q=80" },
                    { 26, "Pizza with cheese stuffed crust", false, "Cheesy Bites", 165.00m, 3, "https://images.unsplash.com/photo-1513104890138-7c749659a591?auto=format&fit=crop&w=800&q=80" },
                    { 27, "8 pieces BBQ chicken wings", true, "Chicken Wings", 95.00m, 3, "https://images.unsplash.com/photo-1565299585323-38d6b0865b47?auto=format&fit=crop&w=800&q=80" },
                    { 28, "Romaine lettuce with caesar dressing", true, "Caesar Salad", 65.00m, 3, "https://images.unsplash.com/photo-1512621776951-a57141f2eefd?auto=format&fit=crop&w=800&q=80" },
                    { 29, "Warm chocolate lava cake", true, "Lava Cake", 55.00m, 3, "https://images.unsplash.com/photo-1578985545062-69928b1d9587?auto=format&fit=crop&w=800&q=80" },
                    { 30, "330ml cold pepsi can", true, "Pepsi Can", 15.00m, 3, "https://images.unsplash.com/photo-1622483767028-3f66f32aef97?auto=format&fit=crop&w=800&q=80" },
                    { 31, "Loaded with all toppings", true, "ExtravaganZZa", 175.00m, 4, "https://images.unsplash.com/photo-1513104890138-7c749659a591?auto=format&fit=crop&w=800&q=80" },
                    { 32, "Triple meat loaded pizza", true, "MeatZZa", 165.00m, 4, "https://images.unsplash.com/photo-1628840042765-356cda07504e?auto=format&fit=crop&w=800&q=80" },
                    { 33, "Fresh garden vegetables pizza", true, "Veggie Feast", 130.00m, 4, "https://images.unsplash.com/photo-1565299624946-b28f40a0ae38?auto=format&fit=crop&w=800&q=80" },
                    { 34, "Cheese filled crust pizza", false, "Stuffed Crust", 155.00m, 4, "https://images.unsplash.com/photo-1513104890138-7c749659a591?auto=format&fit=crop&w=800&q=80" },
                    { 35, "10 pieces crispy chicken bites", true, "Chicken Kickers", 85.00m, 4, "https://images.unsplash.com/photo-1562967914-608f82629710?auto=format&fit=crop&w=800&q=80" },
                    { 36, "Crispy seasoned potato wedges", true, "Potato Wedges", 40.00m, 4, "https://images.unsplash.com/photo-1576107232684-1279f390859f?auto=format&fit=crop&w=800&q=80" },
                    { 37, "Warm chocolate brownie", true, "Brownie", 45.00m, 4, "https://images.unsplash.com/photo-1578985545062-69928b1d9587?auto=format&fit=crop&w=800&q=80" },
                    { 38, "330ml cold diet pepsi", true, "Diet Pepsi", 15.00m, 4, "https://images.unsplash.com/photo-1622483767028-3f66f32aef97?auto=format&fit=crop&w=800&q=80" },
                    { 39, "4 dipping sauces of your choice", true, "Dips Pack", 20.00m, 4, "https://images.unsplash.com/photo-1472476443507-c7a5948772fc?auto=format&fit=crop&w=800&q=80" },
                    { 40, "Garlic bread with melted cheese", true, "Cheesy Garlic Bread", 45.00m, 4, "https://images.unsplash.com/photo-1573140247632-f8fd74997d5c?auto=format&fit=crop&w=800&q=80" },
                    { 41, "Fresh salmon with avocado", false, "Salmon Roll", 150.00m, 5, "https://images.unsplash.com/photo-1579871494447-9811cf80d66c?auto=format&fit=crop&w=800&q=80" },
                    { 42, "8 slices fresh tuna sashimi", false, "Tuna Sashimi", 180.00m, 5, "https://images.unsplash.com/photo-1583623025817-d180a2221d0a?auto=format&fit=crop&w=800&q=80" },
                    { 43, "Shrimp tempura topped with avocado", false, "Dragon Roll", 165.00m, 5, "https://images.unsplash.com/photo-1553621042-f6e147245754?auto=format&fit=crop&w=800&q=80" },
                    { 44, "Traditional Japanese miso soup", false, "Miso Soup", 35.00m, 5, "https://images.unsplash.com/photo-1547592180-85f173990554?auto=format&fit=crop&w=800&q=80" },
                    { 45, "Steamed salted soybeans", false, "Edamame", 40.00m, 5, "https://images.unsplash.com/photo-1512621776951-a57141f2eefd?auto=format&fit=crop&w=800&q=80" },
                    { 46, "Crab, cucumber and avocado", false, "California Roll", 120.00m, 5, "https://images.unsplash.com/photo-1579871494447-9811cf80d66c?auto=format&fit=crop&w=800&q=80" },
                    { 47, "Crispy deep fried prawns", false, "Prawn Tempura", 145.00m, 5, "https://images.unsplash.com/photo-1580894732444-8ecded7900cd?auto=format&fit=crop&w=800&q=80" },
                    { 48, "Pan fried Japanese dumplings", false, "Gyoza", 85.00m, 5, "https://images.unsplash.com/photo-1496116218417-1a781b1c416c?auto=format&fit=crop&w=800&q=80" },
                    { 49, "Matcha flavored ice cream", false, "Green Tea Ice Cream", 55.00m, 5, "https://images.unsplash.com/photo-1572490122747-3968b75cc699?auto=format&fit=crop&w=800&q=80" },
                    { 50, "Rich pork broth noodle soup", false, "Ramen", 130.00m, 5, "https://images.unsplash.com/photo-1557872943-16a5ac26437e?auto=format&fit=crop&w=800&q=80" },
                    { 51, "8 pieces colorful sushi roll", true, "Rainbow Roll", 160.00m, 6, "https://images.unsplash.com/photo-1553621042-f6e147245754?auto=format&fit=crop&w=800&q=80" },
                    { 52, "Tuna with spicy mayo sauce", true, "Spicy Tuna Roll", 145.00m, 6, "https://images.unsplash.com/photo-1579871494447-9811cf80d66c?auto=format&fit=crop&w=800&q=80" },
                    { 53, "Grilled chicken in teriyaki sauce", true, "Chicken Teriyaki", 140.00m, 6, "https://images.unsplash.com/photo-1580894732444-8ecded7900cd?auto=format&fit=crop&w=800&q=80" },
                    { 54, "Crispy shrimp in sushi roll", true, "Shrimp Tempura Roll", 155.00m, 6, "https://images.unsplash.com/photo-1579871494447-9811cf80d66c?auto=format&fit=crop&w=800&q=80" },
                    { 55, "Japanese rice cake with ice cream", true, "Mochi Ice Cream", 65.00m, 6, "https://images.unsplash.com/photo-1572490122747-3968b75cc699?auto=format&fit=crop&w=800&q=80" },
                    { 56, "Grilled chicken skewers", true, "Yakitori", 95.00m, 6, "https://images.unsplash.com/photo-1528735602780-2552fd46c7af?auto=format&fit=crop&w=800&q=80" },
                    { 57, "Japanese octopus balls", false, "Takoyaki", 80.00m, 6, "https://images.unsplash.com/photo-1547592180-85f173990554?auto=format&fit=crop&w=800&q=80" },
                    { 58, "Thick wheat noodles in broth", true, "Udon Noodles", 110.00m, 6, "https://images.unsplash.com/photo-1557872943-16a5ac26437e?auto=format&fit=crop&w=800&q=80" },
                    { 59, "Hot Japanese green tea latte", true, "Matcha Latte", 45.00m, 6, "https://images.unsplash.com/photo-1515823662415-e0fac04ea553?auto=format&fit=crop&w=800&q=80" },
                    { 60, "6 slices fresh salmon sashimi", true, "Salmon Sashimi", 170.00m, 6, "https://images.unsplash.com/photo-1583623025817-d180a2221d0a?auto=format&fit=crop&w=800&q=80" },
                    { 61, "Cheeseburger with ShackSauce", true, "ShackBurger", 130.00m, 7, "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?auto=format&fit=crop&w=800&q=80" },
                    { 62, "Bacon cheeseburger with cherry peppers", true, "SmokeShack", 150.00m, 7, "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?auto=format&fit=crop&w=800&q=80" },
                    { 63, "Cheeseburger with crispy mushroom", true, "Shack Stack", 170.00m, 7, "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?auto=format&fit=crop&w=800&q=80" },
                    { 64, "Classic crinkle cut fries", true, "Crinkle Cut Fries", 45.00m, 7, "https://images.unsplash.com/photo-1576107232684-1279f390859f?auto=format&fit=crop&w=800&q=80" },
                    { 65, "Hand spun vanilla milkshake", true, "Vanilla Shake", 75.00m, 7, "https://images.unsplash.com/photo-1572490122747-3968b75cc699?auto=format&fit=crop&w=800&q=80" },
                    { 66, "Hand spun strawberry milkshake", true, "Strawberry Shake", 75.00m, 7, "https://images.unsplash.com/photo-1572490122747-3968b75cc699?auto=format&fit=crop&w=800&q=80" },
                    { 67, "Crispy chicken sandwich", true, "Chicken Shack", 120.00m, 7, "https://images.unsplash.com/photo-1615486171448-4fc14234c9c7?auto=format&fit=crop&w=800&q=80" },
                    { 68, "Crinkle fries with cheese sauce", false, "Cheese Fries", 60.00m, 7, "https://images.unsplash.com/photo-1576107232684-1279f390859f?auto=format&fit=crop&w=800&q=80" },
                    { 69, "Crispy portobello mushroom burger", true, "Portobello Burger", 125.00m, 7, "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?auto=format&fit=crop&w=800&q=80" },
                    { 70, "Fresh squeezed lemonade", true, "Lemonade", 35.00m, 7, "https://images.unsplash.com/photo-1513558161293-cdaf765ed2fd?auto=format&fit=crop&w=800&q=80" },
                    { 71, "Two beef patties all the way", true, "Five Guys Burger", 155.00m, 8, "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?auto=format&fit=crop&w=800&q=80" },
                    { 72, "Single beef patty burger", true, "Little Burger", 120.00m, 8, "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?auto=format&fit=crop&w=800&q=80" },
                    { 73, "Seasoned fries with cajun spice", true, "Cajun Fries", 50.00m, 8, "https://images.unsplash.com/photo-1576107232684-1279f390859f?auto=format&fit=crop&w=800&q=80" },
                    { 74, "Beef patty with crispy bacon", true, "Bacon Burger", 165.00m, 8, "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?auto=format&fit=crop&w=800&q=80" },
                    { 75, "Choose from 10 mix-in flavors", true, "Milkshake", 80.00m, 8, "https://images.unsplash.com/photo-1572490122747-3968b75cc699?auto=format&fit=crop&w=800&q=80" },
                    { 76, "All beef kosher hot dog", false, "Hot Dog", 90.00m, 8, "https://images.unsplash.com/photo-1612392062631-94dd858cba88?auto=format&fit=crop&w=800&q=80" },
                    { 77, "Toasted bread with melted cheese", true, "Grilled Cheese", 70.00m, 8, "https://images.unsplash.com/photo-1528735602780-2552fd46c7af?auto=format&fit=crop&w=800&q=80" },
                    { 78, "Bacon lettuce and tomato sandwich", true, "BLT Sandwich", 95.00m, 8, "https://images.unsplash.com/photo-1528735602780-2552fd46c7af?auto=format&fit=crop&w=800&q=80" },
                    { 79, "Grilled vegetables in a bun", true, "Veggie Sandwich", 85.00m, 8, "https://images.unsplash.com/photo-1528735602780-2552fd46c7af?auto=format&fit=crop&w=800&q=80" },
                    { 80, "Free refill soft drink", true, "Fountain Drink", 20.00m, 8, "https://images.unsplash.com/photo-1622483767028-3f66f32aef97?auto=format&fit=crop&w=800&q=80" },
                    { 81, "Half pound Angus beef burger", true, "Thickburger", 135.00m, 9, "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?auto=format&fit=crop&w=800&q=80" },
                    { 82, "Crispy fried chicken sandwich", true, "Chicken Fillet", 95.00m, 9, "https://images.unsplash.com/photo-1615486171448-4fc14234c9c7?auto=format&fit=crop&w=800&q=80" },
                    { 83, "Hand scooped natural cut fries", true, "Natural Cut Fries", 35.00m, 9, "https://images.unsplash.com/photo-1576107232684-1279f390859f?auto=format&fit=crop&w=800&q=80" },
                    { 84, "Fries with cheese and bacon", true, "Loaded Fries", 55.00m, 9, "https://images.unsplash.com/photo-1576107232684-1279f390859f?auto=format&fit=crop&w=800&q=80" },
                    { 85, "Beef patty with mushroom sauce", false, "Mushroom Burger", 125.00m, 9, "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?auto=format&fit=crop&w=800&q=80" },
                    { 86, "Crispy battered onion rings", true, "Onion Rings", 30.00m, 9, "https://images.unsplash.com/photo-1626645738196-c2a7c87a8f58?auto=format&fit=crop&w=800&q=80" },
                    { 87, "Eggs bacon and cheese in a wrap", true, "Breakfast Burrito", 75.00m, 9, "https://images.unsplash.com/photo-1528735602780-2552fd46c7af?auto=format&fit=crop&w=800&q=80" },
                    { 88, "Fresh peach milkshake", true, "Peach Shake", 55.00m, 9, "https://images.unsplash.com/photo-1572490122747-3968b75cc699?auto=format&fit=crop&w=800&q=80" },
                    { 89, "Double half pound Angus burger", true, "Double Thickburger", 185.00m, 9, "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?auto=format&fit=crop&w=800&q=80" },
                    { 90, "Classic creamy coleslaw", true, "Cole Slaw", 20.00m, 9, "https://images.unsplash.com/photo-1512621776951-a57141f2eefd?auto=format&fit=crop&w=800&q=80" },
                    { 91, "Crispy buttermilk chicken", false, "Chicken Sandwich", 110.00m, 10, "https://images.unsplash.com/photo-1615486171448-4fc14234c9c7?auto=format&fit=crop&w=800&q=80" },
                    { 92, "3 pieces spicy or mild chicken", false, "3 Piece Chicken", 125.00m, 10, "https://images.unsplash.com/photo-1626645738196-c2a7c87a8f58?auto=format&fit=crop&w=800&q=80" },
                    { 93, "Classic Louisiana red beans rice", false, "Red Beans Rice", 40.00m, 10, "https://images.unsplash.com/photo-1512621776951-a57141f2eefd?auto=format&fit=crop&w=800&q=80" },
                    { 94, "Buttermilk flaky biscuit", false, "Biscuit", 15.00m, 10, "https://images.unsplash.com/photo-1578985545062-69928b1d9587?auto=format&fit=crop&w=800&q=80" },
                    { 95, "Creamy macaroni and cheese", false, "Mac and Cheese", 45.00m, 10, "https://images.unsplash.com/photo-1551183053-bf91a1d81141?auto=format&fit=crop&w=800&q=80" },
                    { 96, "Creamy mashed potatoes with gravy", false, "Mashed Potatoes", 30.00m, 10, "https://images.unsplash.com/photo-1512621776951-a57141f2eefd?auto=format&fit=crop&w=800&q=80" },
                    { 97, "5 pieces chicken tenders", false, "Chicken Tenders", 100.00m, 10, "https://images.unsplash.com/photo-1562967914-608f82629710?auto=format&fit=crop&w=800&q=80" },
                    { 98, "Seasoned Cajun spiced fries", false, "Cajun Fries", 35.00m, 10, "https://images.unsplash.com/photo-1576107232684-1279f390859f?auto=format&fit=crop&w=800&q=80" },
                    { 99, "Fresh strawberry lemonade", false, "Strawberry Lemonade", 40.00m, 10, "https://images.unsplash.com/photo-1513558161293-cdaf765ed2fd?auto=format&fit=crop&w=800&q=80" },
                    { 100, "Extra spicy chicken tenders", false, "Spicy Tenders", 110.00m, 10, "https://images.unsplash.com/photo-1562967914-608f82629710?auto=format&fit=crop&w=800&q=80" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_RestaurantId",
                table: "MenuItem",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_RestaurantId",
                table: "Order",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_MenuItemId",
                table: "OrderItem",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_restaurant_CategoryId",
                table: "restaurant",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "MenuItem");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "restaurant");

            migrationBuilder.DropTable(
                name: "category");
        }
    }
}
