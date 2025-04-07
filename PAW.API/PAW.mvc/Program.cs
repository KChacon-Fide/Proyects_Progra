using PAW.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PAW.mvc.Data;
using PAW.Data.Repository;
using PAW.Repositories;
using APW.Architecture;
using PAW.Services;
using PAW.Architecture.Factory;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PAWmvcContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PAWmvcContext") ?? throw new InvalidOperationException("Connection string 'PAWmvcContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IRestProvider, RestProvider>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IProductFactory, ProductFactory>();
builder.Services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
