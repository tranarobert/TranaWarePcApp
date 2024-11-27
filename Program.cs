using Microsoft.EntityFrameworkCore;
using TranaWarePcApp.Models;
using TranaWarePcApp.Services;
using TranaWarePcApp.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true; // Make the session cookie essential
}
);

builder.Services.AddDbContext<TranaWareContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TranaDb")));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<TranaWareContext>();
/*
builder.Services.AddDefaultIdentity<ApplicationUser>()
        .AddEntityFrameworkStores<TranaWareContext>();
*/

builder.Services.Configure<IdentityOptions>(options =>
{
    //password settings
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    //options.Password.RequiredUniqueChars = 6;

    //lockout settings
    //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
    //options.Lockout.MaxFailedAccessAttempts = 10;
    //options.Lockout.AllowedForNewUsers = true;

    //user settings
    options.User.RequireUniqueEmail = true;
});

builder.Services.AddScoped<IHomeService, HomeService>();
builder.Services.AddScoped<IHomeRepository, HomeRepository>();

builder.Services.AddScoped<IPcComponentService, PcComponentService>();
builder.Services.AddScoped<IPcComponentRepository, PcComponentRepository>();

builder.Services.AddScoped<IUpgradeService, UpgradeService>();
builder.Services.AddScoped<IUpgradeRepository, UpgradeRepository>();

builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddScoped<IBlogRepository, BlogRepository>();

builder.Services.AddScoped<ICartService, CartService>();

builder.Services.AddScoped<IOrderService, OrderService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseSession();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "pagination",
        pattern: "PcComponents/Products/{page}",
        defaults: new { controller = "PcComponents", action = "Products" });

    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapRazorPages();
});



app.Run();
