using JewelryShop.BusinessLayer;
using JewelryShop.DAL;
using JewelryShop.DTO.DTOs;
using JewelryShop.DTO.DTOs.Jewelry;
using JewelryShop.DTO.DTOs.Material.Gem;
using JewelryShop.DTO.DTOs.Material.Metal;
using JewelryShop.DTO.DTOs.Order;
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
    modelBuilder.EntitySet<AccountDTO>("AccountOData");
    modelBuilder.EntitySet<CustomerDTO>("CustomerOData");
    modelBuilder.EntitySet<GuaranteeDTO>("GuaranteeOData");
    modelBuilder.EntitySet<ImageDTO>("ImageOData");
    modelBuilder.EntitySet<JewelryTypeDTO>("JewelryTypeOData");
    modelBuilder.EntitySet<MaterialDTO>("MaterialOData");
    modelBuilder.EntitySet<MaterialPriceDTO>("MaterialPriceOData");
    modelBuilder.EntitySet<OfferDTO>("OfferOData");
    modelBuilder.EntitySet<OrderDiscountDTO>("OrderDiscountOData");
    //modelBuilder.EntitySet<OrderDTO>("OrderOData");
    modelBuilder.EntitySet<OrderTypeDTO>("OrderTypeOData");
    modelBuilder.EntitySet<StoreDiscountDTO>("StoreDiscountOData");
    modelBuilder.EntitySet<GemResponse>("GemOData");
    modelBuilder.EntitySet<MetalResponse>("MetalOData");
    modelBuilder.EntitySet<JewelryResponse>("JewelryOData");
    modelBuilder.EntitySet<OrderResponse>("OrderOData");
    //modelBuilder.EntitySet<TierDTO>("TierOData");
    return modelBuilder.GetEdmModel();
}