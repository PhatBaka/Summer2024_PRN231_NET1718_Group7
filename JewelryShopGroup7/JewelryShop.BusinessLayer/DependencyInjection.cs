
using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.BusinessLayer.Mapper;
using JewelryShop.BusinessLayer.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddBusinessLayer(this IServiceCollection services)
    {
        //Service
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IGuaranteeService, GuaranteeService>();
        services.AddScoped<IJewelryMaterialService, JewelryMaterialService>();
        services.AddScoped<IJewelryService, JewelryService>();
        services.AddScoped<IJewelryTypeService, JewelryTypeService>();
        services.AddScoped<IMaterialPriceService, MaterialPriceService>();
        services.AddScoped<IMaterialService, MaterialService>();
        services.AddScoped<IOfferService, OfferService>();
        services.AddScoped<IOrderDetailService, OrderDetailService>();
        services.AddScoped<IOrderDiscountService, OrderDiscountService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IOrderTypeService, OrderTypeService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IStoreDiscountService, StoreDiscountService>();
        services.AddScoped<ITierService, TierService>();
        services.AddScoped<IImageService, ImageService>();

        //Mapper
        services.AddAutoMapper(typeof(MappingProfile));
        return services;
    }
}