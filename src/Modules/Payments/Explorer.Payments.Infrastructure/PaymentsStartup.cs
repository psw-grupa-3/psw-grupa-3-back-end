using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Payments.API.Public;
using Explorer.Payments.API.Public.Shopping;
using Explorer.Payments.Core.Domain;
using Explorer.Payments.Core.Domain.Order;
using Explorer.Payments.Core.Domain.RepositoryInterfaces;
using Explorer.Payments.Core.Mappers;
using Explorer.Payments.Core.UseCases.Shopping;
using Explorer.Payments.Infrastructure.Database;
using Explorer.Tours.Core.UseCases.Shopping;
using Explorer.Tours.Infrastructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Payments.Infrastructure;

public static class PaymentsStartup
{
    public static IServiceCollection ConfigurePaymentsModule(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(PaymentsProfile).Assembly);
        SetupCore(services);
        SetupInfrastructure(services);
        return services;
    }

    private static void SetupInfrastructure(IServiceCollection services)
    {
        services.AddScoped(typeof(ICrudRepository<Payment>),
            typeof(CrudDatabaseRepository<Payment, PaymentsContext>));

        services.AddDbContext<PaymentsContext>(opt =>
            opt.UseNpgsql(DbConnectionStringBuilder.Build("payment"),
                x => x.MigrationsHistoryTable("__EFMigrationsHistory", "payment")));

        services.AddScoped(typeof(ICrudRepository<ShoppingCart>), typeof(CrudDatabaseRepository<ShoppingCart, PaymentsContext>));
        services.AddScoped(typeof(ICrudRepository<TourPurchaseToken>), typeof(CrudDatabaseRepository<TourPurchaseToken, PaymentsContext>));
        services.AddScoped(typeof(IOrderRepository), typeof(OrderRepository));
        services.AddScoped(typeof(ITourPurchaseTokenRepository), typeof(TourPurchaseTokenRepository));

    }

    private static void SetupCore(IServiceCollection services)
    {
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<ITourPurchaseTokenService, TourPurchaseTokenService>();
    }
}
