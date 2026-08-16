using CorsoGestioneDB.Abstractions.Interfaces;
using CorsoGestioneDB.Infrastructure.Database;
using CorsoGestioneDB.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CorsoGestioneDB.Infrastructure.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // Registrazione dei repository che accedono al database
        services.AddSingleton<DbConnectionFactory>();
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddTransient<ICityRepository, CityRepository>();
        services.AddTransient<ICustomerRepository, CustomerRepository>();
        services.AddTransient<ILocationInfoRepository, LocationInfoRepository>();
        services.AddTransient<IOrderRepository, OrderRepository>();
        services.AddTransient<IOrderLineRepository, OrderLineRepository>();
        services.AddTransient<IOrderStatusRepository, OrderStatusRepository>();
        services.AddTransient<IPaymentMethodRepository, PaymentMethodRepository>();
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<IProvinceRepository, ProvinceRepository>();
        services.AddTransient<IRegionRepository, RegionRepository>();
        services.AddTransient<IStagingOrderRepository, StagingOrderRepository>();

        return services;
    }
}
