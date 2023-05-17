using Microsoft.EntityFrameworkCore;
using Store.Core.Domain.Baskets;
using Store.Core.Domain.Categories;
using Store.Core.Domain.Orders;
using Store.Core.Domain.Products;
using Store.Infrastructure.Data.SQLServer.Categories;
using Store.Infrastructure.Data.SQLServer.Common;
using Store.Infrastructure.Data.SQLServer.Orders;
using Store.Infrastructure.Data.SQLServer.Products;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<StoreDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("StoreCnn")));
builder.Services.AddScoped<IProductRepository, EFProductRepository>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<Basket>(sp => SessionBasket.GetBasket(sp));
builder.Services.AddScoped<IOrderRepository, EFOrderRepository>();
builder.Services.AddScoped<ICategoryRepository, EFCategoryRepository>();
builder.Services.AddMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("Pagination", "/{controller=home}/{action=index}/{category}/Page-{pageNumber}");
    endpoints.MapControllerRoute("Pagination", "/{controller=home}/{action=index}/Page-{pageNumber}");
    endpoints.MapControllerRoute("Pagination", "/{controller=home}/{action=index}/{category}");
    endpoints.MapDefaultControllerRoute();
});

app.Run();
