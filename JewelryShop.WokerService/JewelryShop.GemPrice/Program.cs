using JewelryShop.GemPrice.DataAccessObjects.Impls;
using JewelryShop.GemPrice.DataAccessObjects.Interfaces;
using JewelryShop.GemPrice.Models;
using JewelryShop.GemPrice.Repositories.Impls;
using JewelryShop.GemPrice.Repositories.Interfaces;

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
builder.Services.AddScoped<IGemRepo, GemRepo>();

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
