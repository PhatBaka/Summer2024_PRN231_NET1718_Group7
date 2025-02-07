using JewelryShop.DAL.Models;
using JewelryShop.DAL.Repositories.Implements;
using JewelryShop.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.Design;

namespace JewelryShop.DAL;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
    {
        //Database
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("JewelryShop"),
        b => b.MigrationsAssembly(typeof(ServiceContainer).Assembly.FullName)),
        ServiceLifetime.Scoped);

        //Service
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IGuaranteeRepository, GuaranteeRepository>();
        //services.AddScoped<IJewelryMaterialRepository, JewelryMaterialRepository>();
        services.AddScoped<IJewelryRepository, JewelryRepository>();
        services.AddScoped<IMaterialRepository, MaterialRepository>();
        services.AddScoped<IOfferRepository, OfferRepository>();
        services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
        services.AddScoped<IOrderDiscountRepository, OrderDiscountRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IStoreDiscountRepository, StoreDiscountRepository>();
        services.AddScoped<ITierRepository, TierRepository>();
        services.AddScoped<IImageRepository, ImageRepository>();

        return services;
    }
}