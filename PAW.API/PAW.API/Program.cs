using APW.Architecture;
using Microsoft.AspNetCore.Identity;
using PAW.Architecture.Factory;
using PAW.Business;
using PAW.Data.Repository;
using PAW.Models;
using PAW.Repositories;
using PAW.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductManager, ProductManager>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<IRestProvider, RestProvider>();
builder.Services.AddScoped<IFinanceService, FinanceService>();

builder.Services.AddScoped<ICategoryManager, CategoryManager>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
builder.Services.AddScoped<IInventoryManager, InventoryManager>();

builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleManager, RoleManager>();

builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<ISupplierManager, SupplierManager>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserManager, UserManager>();

builder.Services.AddTransient<IProductFactory, ProductFactory>();

builder.Services.AddTransient<IProductFactory, ProductFactory>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IRepositoryBase<Product>, RepositoryBase<Product>>();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();





var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
