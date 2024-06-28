using JewelryShop.BusinessLayer;
using JewelryShop.DAL;
using JewelryShop.DTO.DTOs;
using JewelryShop.DTO.DTOs.Account;
using JewelryShop.DTO.DTOs.Customer;
using JewelryShop.DTO.DTOs.Guarantee;
using JewelryShop.DTO.DTOs.Image;
using JewelryShop.DTO.DTOs.Jewelry;
using JewelryShop.DTO.DTOs.JewelryMaterial;
using JewelryShop.DTO.DTOs.Material;
using JewelryShop.DTO.DTOs.Offer;
using JewelryShop.DTO.DTOs.Order;
using JewelryShop.DTO.DTOs.OrderDetail;
using JewelryShop.DTO.DTOs.OrderDiscount;
using JewelryShop.DTO.DTOs.StoreDiscount;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddOData(opt =>
          opt.AddRouteComponents("odata", GetEdmModel())
              .Select()
              .Filter()
              .OrderBy()
              .Expand()
              .Count()  // Enable $count
              .SetMaxTop(100));

builder.Services.AddMvc(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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


static IEdmModel GetEdmModel()
{
    ODataConventionModelBuilder modelBuilder = new ODataConventionModelBuilder();
    modelBuilder.EntitySet<AccountResponse>("AccountOData");
    modelBuilder.EntitySet<CustomerResponse>("CustomerOData");
    modelBuilder.EntitySet<GuaranteeResponse>("GuaranteeOData");
    modelBuilder.EntitySet<ImageResponse>("ImageOData");
    modelBuilder.EntitySet<JewelryResponse>("JewelryOData");
    modelBuilder.EntitySet<MaterialResponse>("MaterialOData");
    modelBuilder.EntitySet<JewelryMaterialResponse>("JewelryMaterialOData");
    modelBuilder.EntitySet<OfferResponse>("OfferOData");
    modelBuilder.EntitySet<OrderDiscountResponse>("OrderDiscountOData");
    modelBuilder.EntitySet<OrderDetailResponse>("OrderDetailOData");
    modelBuilder.EntitySet<OrderResponse>("OrderOData");
    modelBuilder.EntitySet<StoreDiscountResponse>("StoreDiscountOData");
    return modelBuilder.GetEdmModel();
}