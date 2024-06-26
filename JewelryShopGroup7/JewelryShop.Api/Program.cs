using JewelryShop.BusinessLayer;
using JewelryShop.BusinessLayer.BackgroundServices;
using JewelryShop.DAL;
using JewelryShop.DAL.Models;
using JewelryShop.DAL.Seed;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMvc(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the HttpClient with increased timeout
builder.Services.AddHttpClient<PriceUpdaterService>(client =>
{
    client.Timeout = TimeSpan.FromMinutes(5); // Set the timeout to 5 minutes
});
// Register the hosted service
builder.Services.AddHostedService<PriceUpdaterService>();

builder.Services.AddDataAccessLayer(builder.Configuration);
builder.Services.AddBusinessLayer();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try
{
    var context = services.GetRequiredService<AppDbContext>();
    await context.Database.MigrateAsync();
    await Seed.SeedAcc(context);
    await Seed.SeedJew(context);
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error while seeding data");
}


app.Run();
