using CleanArchitecture.Application;
using JewelryShop.BusinessLayer.BackgroundServices;
using PhotoboothBranchService.Domain.Common.Interfaces;

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

app.Run();
