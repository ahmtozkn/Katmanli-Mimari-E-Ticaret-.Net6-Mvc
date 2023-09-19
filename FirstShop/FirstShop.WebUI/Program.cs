using FirstShop.Business.Managers;
using FirstShop.Business.Services;
using FirstShop.Data.Context;
using FirstShop.Data.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<FirstShopContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped(typeof(IRepository<>), typeof(SqlRepository<>));


builder.Services.AddScoped<IUserService, UserManager>();

builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<ICartService, CartManager>();
builder.Services.AddScoped<ICartItemService, CartItemManager>();
builder.Services.AddScoped<ICommentService, CommentManager>();
builder.Services.AddScoped<IOrderDetailService, OrderDetailManager>();
builder.Services.AddScoped<IOrderService, OrderManager>();
builder.Services.AddScoped<IAddressService, AddressManager>();
builder.Services.AddScoped<ILikeService, LikeManager>();
builder.Services.AddScoped<IPaymentMethodService,PaymentMethodManager>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = new PathString("/");
    options.LogoutPath = new PathString("/");
    options.AccessDeniedPath = new PathString("/");
   
});

var app = builder.Build();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=dashboard}/{action=index}/{id?}"
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=home}/{action=index}/{id?}"
    );
app.Run();
