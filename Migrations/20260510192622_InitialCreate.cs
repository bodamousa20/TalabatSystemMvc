using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TalabatSmartVillage.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
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
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "A78adjdnmjj5214-03945fv%43mf", "A78adjdnmjj5214-03945fv%43mf", "ADMIN", "ADMIN" },
                    { "bkdd8ad52mjj5214-03945fv%43ds", "bkdd8ad52mjj5214-03945fv%43ds", "USER", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "postalcode" },
                values: new object[] { "adminsIdFakerIdes125d$2$@E@23", 0, "Admin Address", "ae56e2eb-a436-4980-adf5-14e3ec424a83", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@gmail.com", true, "Admin", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEKCc38T78doP4i8xDcHSarN9K8s9boaQ/tqiUNFdI+vO+jTenMkuJmuCCfNgnQP0NQ==", null, false, "ff917ecc-c7f6-446a-a286-475b554d5fc0", false, "admin@gmail.com", 0 });

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Fast Food" },
                    { 2, "Pizza" },
                    { 3, "Sushi" },
                    { 4, "Burgers" },
                    { 5, "Chicken" },
                    { 6, "Seafood" },
                    { 7, "Desserts" },
                    { 8, "Healthy" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "A78adjdnmjj5214-03945fv%43mf", "adminsIdFakerIdes125d$2$@E@23" });

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
                    { 1, "Crispy spicy chicken burger", true, "Zinger Burger", 85.00m, 1, "https://www.kfc.com.au/images/products/zinger-burger.jpg" },
                    { 2, "8 pieces crispy chicken bucket", true, "Bucket Meal", 250.00m, 1, "https://www.kfc.com/images/products/bucket.jpg" },
                    { 3, "Fresh creamy coleslaw side", true, "Coleslaw", 20.00m, 1, "https://www.seriouseats.com/thmb/coleslaw.jpg" },
                    { 4, "Cold refreshing drink", true, "Pepsi", 15.00m, 1, "https://upload.wikimedia.org/wikipedia/commons/thumb/6/6f/Pepsi_can.png/800px-Pepsi_can.png" },
                    { 5, "6 pieces spicy hot wings", true, "Hot Wings", 75.00m, 1, "https://www.seriouseats.com/thmb/hot-wings.jpg" },
                    { 6, "Grilled chicken in a flour wrap", false, "Twister Wrap", 70.00m, 1, "https://www.kfc.com/images/products/twister.jpg" },
                    { 7, "Creamy mashed potato with gravy", true, "Mashed Potato", 25.00m, 1, "https://www.seriouseats.com/thmb/mashed-potato.jpg" },
                    { 8, "Rich moist chocolate slice", true, "Chocolate Cake", 35.00m, 1, "https://www.seriouseats.com/thmb/chocolate-cake.jpg" },
                    { 9, "12 pieces with 2 sides and drinks", true, "Family Meal", 450.00m, 1, "https://www.kfc.com/images/products/family-meal.jpg" },
                    { 10, "Grilled sweet corn side", true, "Corn on the Cob", 18.00m, 1, "https://www.seriouseats.com/thmb/corn-cob.jpg" },
                    { 11, "Classic double beef burger", true, "Big Mac", 95.00m, 2, "https://images.themodernproper.com/production/posts/2016/ClassicCheeseBurger_9.jpg?w=1200&h=1200&q=60&fm=jpg&fit=crop&dm=1749310239&s=463b18fc3bb51dc5d96e866c848527c4" },
                    { 12, "Golden crispy french fries", true, "McFries", 30.00m, 2, "https://www.seriouseats.com/thmb/french-fries.jpg" },
                    { 13, "Vanilla ice cream with Oreo", true, "McFlurry Oreo", 45.00m, 2, "https://www.seriouseats.com/thmb/mcflurry.jpg" },
                    { 14, "10 pieces crispy nuggets", true, "Chicken McNuggets", 80.00m, 2, "https://www.seriouseats.com/thmb/nuggets.jpg" },
                    { 15, "Quarter pound beef patty burger", true, "Quarter Pounder", 105.00m, 2, "https://www.seriouseats.com/thmb/quarter-pounder.jpg" },
                    { 16, "Warm baked apple pie", true, "Apple Pie", 20.00m, 2, "https://www.seriouseats.com/thmb/apple-pie.jpg" },
                    { 17, "Crispy fish fillet burger", false, "Filet-O-Fish", 75.00m, 2, "https://www.seriouseats.com/thmb/filet-o-fish.jpg" },
                    { 18, "Thick creamy chocolate milkshake", true, "Chocolate Shake", 40.00m, 2, "https://www.seriouseats.com/thmb/chocolate-shake.jpg" },
                    { 19, "Kids meal with toy", true, "Happy Meal", 65.00m, 2, "https://www.seriouseats.com/thmb/happy-meal.jpg" },
                    { 20, "Double beef with double cheese", true, "Double Cheeseburger", 85.00m, 2, "https://www.seriouseats.com/thmb/double-cheeseburger.jpg" },
                    { 21, "Classic tomato and mozzarella", true, "Margherita", 120.00m, 3, "https://upload.wikimedia.org/wikipedia/commons/a/a3/Eq_it-na_pizza-margherita_sep2005_sml.jpg" },
                    { 22, "Loaded spicy pepperoni pizza", true, "Pepperoni", 145.00m, 3, "https://upload.wikimedia.org/wikipedia/commons/a/a3/Eq_it-na_pizza-margherita_sep2005_sml.jpg" },
                    { 23, "BBQ sauce with grilled chicken", true, "BBQ Chicken", 155.00m, 3, "https://www.seriouseats.com/thmb/bbq-chicken-pizza.jpg" },
                    { 24, "Toasted garlic butter bread", true, "Garlic Bread", 35.00m, 3, "https://www.seriouseats.com/thmb/garlic-bread.jpg" },
                    { 25, "Spicy tomato pasta", true, "Pasta Arrabiata", 90.00m, 3, "https://www.seriouseats.com/thmb/pasta-arrabiata.jpg" },
                    { 26, "Pizza with cheese stuffed crust", false, "Cheesy Bites", 165.00m, 3, "https://www.seriouseats.com/thmb/cheesy-bites.jpg" },
                    { 27, "8 pieces BBQ chicken wings", true, "Chicken Wings", 95.00m, 3, "https://www.seriouseats.com/thmb/chicken-wings.jpg" },
                    { 28, "Romaine lettuce with caesar dressing", true, "Caesar Salad", 65.00m, 3, "https://www.seriouseats.com/thmb/caesar-salad.jpg" },
                    { 29, "Warm chocolate lava cake", true, "Lava Cake", 55.00m, 3, "https://www.seriouseats.com/thmb/lava-cake.jpg" },
                    { 30, "330ml cold pepsi can", true, "Pepsi Can", 15.00m, 3, "https://upload.wikimedia.org/wikipedia/commons/thumb/6/6f/Pepsi_can.png/800px-Pepsi_can.png" },
                    { 31, "Loaded with all toppings", true, "ExtravaganZZa", 175.00m, 4, "https://upload.wikimedia.org/wikipedia/commons/a/a3/Eq_it-na_pizza-margherita_sep2005_sml.jpg" },
                    { 32, "Triple meat loaded pizza", true, "MeatZZa", 165.00m, 4, "https://www.seriouseats.com/thmb/meatzza.jpg" },
                    { 33, "Fresh garden vegetables pizza", true, "Veggie Feast", 130.00m, 4, "https://www.seriouseats.com/thmb/veggie-pizza.jpg" },
                    { 34, "Cheese filled crust pizza", false, "Stuffed Crust", 155.00m, 4, "https://www.seriouseats.com/thmb/stuffed-crust.jpg" },
                    { 35, "10 pieces crispy chicken bites", true, "Chicken Kickers", 85.00m, 4, "https://www.seriouseats.com/thmb/chicken-kickers.jpg" },
                    { 36, "Crispy seasoned potato wedges", true, "Potato Wedges", 40.00m, 4, "https://www.seriouseats.com/thmb/potato-wedges.jpg" },
                    { 37, "Warm chocolate brownie", true, "Brownie", 45.00m, 4, "https://www.seriouseats.com/thmb/brownie.jpg" },
                    { 38, "330ml cold diet pepsi", true, "Diet Pepsi", 15.00m, 4, "https://upload.wikimedia.org/wikipedia/commons/thumb/6/6f/Pepsi_can.png/800px-Pepsi_can.png" },
                    { 39, "4 dipping sauces of your choice", true, "Dips Pack", 20.00m, 4, "https://www.seriouseats.com/thmb/dips.jpg" },
                    { 40, "Garlic bread with melted cheese", true, "Cheesy Garlic Bread", 45.00m, 4, "https://www.seriouseats.com/thmb/cheesy-garlic-bread.jpg" },
                    { 41, "Fresh salmon with avocado", false, "Salmon Roll", 150.00m, 5, "https://upload.wikimedia.org/wikipedia/commons/6/60/Sushi_platter.jpg" },
                    { 42, "8 slices fresh tuna sashimi", false, "Tuna Sashimi", 180.00m, 5, "https://upload.wikimedia.org/wikipedia/commons/6/60/Sushi_platter.jpg" },
                    { 43, "Shrimp tempura topped with avocado", false, "Dragon Roll", 165.00m, 5, "https://upload.wikimedia.org/wikipedia/commons/6/60/Sushi_platter.jpg" },
                    { 44, "Traditional Japanese miso soup", false, "Miso Soup", 35.00m, 5, "https://upload.wikimedia.org/wikipedia/commons/6/60/Sushi_platter.jpg" },
                    { 45, "Steamed salted soybeans", false, "Edamame", 40.00m, 5, "https://upload.wikimedia.org/wikipedia/commons/6/60/Sushi_platter.jpg" },
                    { 46, "Crab, cucumber and avocado", false, "California Roll", 120.00m, 5, "https://upload.wikimedia.org/wikipedia/commons/6/60/Sushi_platter.jpg" },
                    { 47, "Crispy deep fried prawns", false, "Prawn Tempura", 145.00m, 5, "https://upload.wikimedia.org/wikipedia/commons/6/60/Sushi_platter.jpg" },
                    { 48, "Pan fried Japanese dumplings", false, "Gyoza", 85.00m, 5, "https://upload.wikimedia.org/wikipedia/commons/6/60/Sushi_platter.jpg" },
                    { 49, "Matcha flavored ice cream", false, "Green Tea Ice Cream", 55.00m, 5, "https://upload.wikimedia.org/wikipedia/commons/6/60/Sushi_platter.jpg" },
                    { 50, "Rich pork broth noodle soup", false, "Ramen", 130.00m, 5, "https://upload.wikimedia.org/wikipedia/commons/6/60/Sushi_platter.jpg" },
                    { 51, "8 pieces colorful sushi roll", true, "Rainbow Roll", 160.00m, 6, "https://upload.wikimedia.org/wikipedia/commons/6/60/Sushi_platter.jpg" },
                    { 52, "Tuna with spicy mayo sauce", true, "Spicy Tuna Roll", 145.00m, 6, "https://upload.wikimedia.org/wikipedia/commons/6/60/Sushi_platter.jpg" },
                    { 53, "Grilled chicken in teriyaki sauce", true, "Chicken Teriyaki", 140.00m, 6, "https://upload.wikimedia.org/wikipedia/commons/6/60/Sushi_platter.jpg" },
                    { 54, "Crispy shrimp in sushi roll", true, "Shrimp Tempura Roll", 155.00m, 6, "https://upload.wikimedia.org/wikipedia/commons/6/60/Sushi_platter.jpg" },
                    { 55, "Japanese rice cake with ice cream", true, "Mochi Ice Cream", 65.00m, 6, "https://upload.wikimedia.org/wikipedia/commons/6/60/Sushi_platter.jpg" },
                    { 56, "Grilled chicken skewers", true, "Yakitori", 95.00m, 6, "https://upload.wikimedia.org/wikipedia/commons/6/60/Sushi_platter.jpg" },
                    { 57, "Japanese octopus balls", false, "Takoyaki", 80.00m, 6, "https://upload.wikimedia.org/wikipedia/commons/6/60/Sushi_platter.jpg" },
                    { 58, "Thick wheat noodles in broth", true, "Udon Noodles", 110.00m, 6, "https://upload.wikimedia.org/wikipedia/commons/6/60/Sushi_platter.jpg" },
                    { 59, "Hot Japanese green tea latte", true, "Matcha Latte", 45.00m, 6, "https://upload.wikimedia.org/wikipedia/commons/6/60/Sushi_platter.jpg" },
                    { 60, "6 slices fresh salmon sashimi", true, "Salmon Sashimi", 170.00m, 6, "https://upload.wikimedia.org/wikipedia/commons/6/60/Sushi_platter.jpg" },
                    { 61, "Cheeseburger with ShackSauce", true, "ShackBurger", 130.00m, 7, "https://images.themodernproper.com/production/posts/2016/ClassicCheeseBurger_9.jpg?w=1200&h=1200&q=60&fm=jpg&fit=crop&dm=1749310239&s=463b18fc3bb51dc5d96e866c848527c4" },
                    { 62, "Bacon cheeseburger with cherry peppers", true, "SmokeShack", 150.00m, 7, "https://images.themodernproper.com/production/posts/2016/ClassicCheeseBurger_9.jpg?w=1200&h=1200&q=60&fm=jpg&fit=crop&dm=1749310239&s=463b18fc3bb51dc5d96e866c848527c4" },
                    { 63, "Cheeseburger with crispy mushroom", true, "Shack Stack", 170.00m, 7, "https://images.themodernproper.com/production/posts/2016/ClassicCheeseBurger_9.jpg?w=1200&h=1200&q=60&fm=jpg&fit=crop&dm=1749310239&s=463b18fc3bb51dc5d96e866c848527c4" },
                    { 64, "Classic crinkle cut fries", true, "Crinkle Cut Fries", 45.00m, 7, "https://www.seriouseats.com/thmb/french-fries.jpg" },
                    { 65, "Hand spun vanilla milkshake", true, "Vanilla Shake", 75.00m, 7, "https://www.seriouseats.com/thmb/vanilla-shake.jpg" },
                    { 66, "Hand spun strawberry milkshake", true, "Strawberry Shake", 75.00m, 7, "https://www.seriouseats.com/thmb/strawberry-shake.jpg" },
                    { 67, "Crispy chicken sandwich", true, "Chicken Shack", 120.00m, 7, "https://www.seriouseats.com/thmb/chicken-sandwich.jpg" },
                    { 68, "Crinkle fries with cheese sauce", false, "Cheese Fries", 60.00m, 7, "https://www.seriouseats.com/thmb/cheese-fries.jpg" },
                    { 69, "Crispy portobello mushroom burger", true, "Portobello Burger", 125.00m, 7, "https://images.themodernproper.com/production/posts/2016/ClassicCheeseBurger_9.jpg?w=1200&h=1200&q=60&fm=jpg&fit=crop&dm=1749310239&s=463b18fc3bb51dc5d96e866c848527c4" },
                    { 70, "Fresh squeezed lemonade", true, "Lemonade", 35.00m, 7, "https://www.seriouseats.com/thmb/lemonade.jpg" },
                    { 71, "Two beef patties all the way", true, "Five Guys Burger", 155.00m, 8, "https://images.themodernproper.com/production/posts/2016/ClassicCheeseBurger_9.jpg?w=1200&h=1200&q=60&fm=jpg&fit=crop&dm=1749310239&s=463b18fc3bb51dc5d96e866c848527c4" },
                    { 72, "Single beef patty burger", true, "Little Burger", 120.00m, 8, "https://images.themodernproper.com/production/posts/2016/ClassicCheeseBurger_9.jpg?w=1200&h=1200&q=60&fm=jpg&fit=crop&dm=1749310239&s=463b18fc3bb51dc5d96e866c848527c4" },
                    { 73, "Seasoned fries with cajun spice", true, "Cajun Fries", 50.00m, 8, "https://www.seriouseats.com/thmb/cajun-fries.jpg" },
                    { 74, "Beef patty with crispy bacon", true, "Bacon Burger", 165.00m, 8, "https://images.themodernproper.com/production/posts/2016/ClassicCheeseBurger_9.jpg?w=1200&h=1200&q=60&fm=jpg&fit=crop&dm=1749310239&s=463b18fc3bb51dc5d96e866c848527c4" },
                    { 75, "Choose from 10 mix-in flavors", true, "Milkshake", 80.00m, 8, "https://www.seriouseats.com/thmb/milkshake.jpg" },
                    { 76, "All beef kosher hot dog", false, "Hot Dog", 90.00m, 8, "https://www.seriouseats.com/thmb/hot-dog.jpg" },
                    { 77, "Toasted bread with melted cheese", true, "Grilled Cheese", 70.00m, 8, "https://www.seriouseats.com/thmb/grilled-cheese.jpg" },
                    { 78, "Bacon lettuce and tomato sandwich", true, "BLT Sandwich", 95.00m, 8, "https://www.seriouseats.com/thmb/blt-sandwich.jpg" },
                    { 79, "Grilled vegetables in a bun", true, "Veggie Sandwich", 85.00m, 8, "https://www.seriouseats.com/thmb/veggie-sandwich.jpg" },
                    { 80, "Free refill soft drink", true, "Fountain Drink", 20.00m, 8, "https://upload.wikimedia.org/wikipedia/commons/thumb/6/6f/Pepsi_can.png/800px-Pepsi_can.png" },
                    { 81, "Half pound Angus beef burger", true, "Thickburger", 135.00m, 9, "https://images.themodernproper.com/production/posts/2016/ClassicCheeseBurger_9.jpg?w=1200&h=1200&q=60&fm=jpg&fit=crop&dm=1749310239&s=463b18fc3bb51dc5d96e866c848527c4" },
                    { 82, "Crispy fried chicken sandwich", true, "Chicken Fillet", 95.00m, 9, "https://www.seriouseats.com/thmb/chicken-sandwich.jpg" },
                    { 83, "Hand scooped natural cut fries", true, "Natural Cut Fries", 35.00m, 9, "https://www.seriouseats.com/thmb/french-fries.jpg" },
                    { 84, "Fries with cheese and bacon", true, "Loaded Fries", 55.00m, 9, "https://www.seriouseats.com/thmb/loaded-fries.jpg" },
                    { 85, "Beef patty with mushroom sauce", false, "Mushroom Burger", 125.00m, 9, "https://images.themodernproper.com/production/posts/2016/ClassicCheeseBurger_9.jpg?w=1200&h=1200&q=60&fm=jpg&fit=crop&dm=1749310239&s=463b18fc3bb51dc5d96e866c848527c4" },
                    { 86, "Crispy battered onion rings", true, "Onion Rings", 30.00m, 9, "https://www.seriouseats.com/thmb/onion-rings.jpg" },
                    { 87, "Eggs bacon and cheese in a wrap", true, "Breakfast Burrito", 75.00m, 9, "https://www.seriouseats.com/thmb/breakfast-burrito.jpg" },
                    { 88, "Fresh peach milkshake", true, "Peach Shake", 55.00m, 9, "https://www.seriouseats.com/thmb/peach-shake.jpg" },
                    { 89, "Double half pound Angus burger", true, "Double Thickburger", 185.00m, 9, "https://images.themodernproper.com/production/posts/2016/ClassicCheeseBurger_9.jpg?w=1200&h=1200&q=60&fm=jpg&fit=crop&dm=1749310239&s=463b18fc3bb51dc5d96e866c848527c4" },
                    { 90, "Classic creamy coleslaw", true, "Cole Slaw", 20.00m, 9, "https://www.seriouseats.com/thmb/coleslaw.jpg" },
                    { 91, "Crispy buttermilk chicken", false, "Chicken Sandwich", 110.00m, 10, "https://www.seriouseats.com/thmb/chicken-sandwich.jpg" },
                    { 92, "3 pieces spicy or mild chicken", false, "3 Piece Chicken", 125.00m, 10, "https://www.seriouseats.com/thmb/fried-chicken.jpg" },
                    { 93, "Classic Louisiana red beans rice", false, "Red Beans Rice", 40.00m, 10, "https://www.seriouseats.com/thmb/red-beans-rice.jpg" },
                    { 94, "Buttermilk flaky biscuit", false, "Biscuit", 15.00m, 10, "https://www.seriouseats.com/thmb/biscuit.jpg" },
                    { 95, "Creamy macaroni and cheese", false, "Mac and Cheese", 45.00m, 10, "https://www.seriouseats.com/thmb/mac-cheese.jpg" },
                    { 96, "Creamy mashed potatoes with gravy", false, "Mashed Potatoes", 30.00m, 10, "https://www.seriouseats.com/thmb/mashed-potato.jpg" },
                    { 97, "5 pieces chicken tenders", false, "Chicken Tenders", 100.00m, 10, "https://www.seriouseats.com/thmb/chicken-tenders.jpg" },
                    { 98, "Seasoned Cajun spiced fries", false, "Cajun Fries", 35.00m, 10, "https://www.seriouseats.com/thmb/cajun-fries.jpg" },
                    { 99, "Fresh strawberry lemonade", false, "Strawberry Lemonade", 40.00m, 10, "https://www.seriouseats.com/thmb/lemonade.jpg" },
                    { 100, "Extra spicy chicken tenders", false, "Spicy Tenders", 110.00m, 10, "https://www.seriouseats.com/thmb/spicy-tenders.jpg" }
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
