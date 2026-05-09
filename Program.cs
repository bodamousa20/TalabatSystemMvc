using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using TalabatSmartVillage.Auth;
using TalabatSmartVillage.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(op =>
    op.UseSqlServer(builder.Configuration.GetConnectionString("connectioStr")));

builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.Password.RequiredLength = 8;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase  = true;
    options.Password.RequireDigit = true;

}).AddEntityFrameworkStores<AppDbContext>();

//Allow Only Authroized User

builder.Services.AddAuthorization(option =>
{
    option.FallbackPolicy =
                        new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
});
//FallBack Url
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();



app.MapControllerRoute(    
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();