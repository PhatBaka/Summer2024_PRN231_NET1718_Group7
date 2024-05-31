using JewleryShop.MetalPrice.DataAccessObjects.Impls;
using JewleryShop.MetalPrice.DataAccessObjects.Interfaces;
using JewleryShop.MetalPrice.Models;
using JewleryShop.MetalPrice.Repositories.Impls;
using JewleryShop.MetalPrice.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMvc(options =>
{
	options.SuppressAsyncSuffixInActionNames = false;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<AppDBContext>();
builder.Services.AddScoped(typeof(IGenericDAO<>), typeof(GenericDAO<>));
builder.Services.AddScoped<IMetalRepo, MetalRepo>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
