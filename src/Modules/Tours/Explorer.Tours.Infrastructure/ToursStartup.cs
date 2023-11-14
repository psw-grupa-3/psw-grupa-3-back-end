using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Tours.API.Public;
using Explorer.Tours.API.Public.Administration;
using Explorer.Tours.API.Public.Personalization;
using Explorer.Tours.API.Public.Shopping;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.Order;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Domain.Tours;
using Explorer.Tours.Core.Domain.TourExecutions;
using Explorer.Tours.Core.Mappers;
using Explorer.Tours.Core.UseCases;
using Explorer.Tours.Core.UseCases.Administration;
using Explorer.Tours.Core.UseCases.Personalization;
using Explorer.Tours.Core.UseCases.Shopping;
using Explorer.Tours.Infrastructure.Database;
using Explorer.Tours.Infrastructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Object = Explorer.Tours.Core.Domain.Object;

namespace Explorer.Tours.Infrastructure;

public static class ToursStartup
{
    public static IServiceCollection ConfigureToursModule(this IServiceCollection services)
    {
        // Registers all profiles since it works on the assembly
        services.AddAutoMapper(typeof(ToursProfile).Assembly);
        services.AddAutoMapper(typeof(TourExecutionProfile).Assembly);
        SetupCore(services);
        SetupInfrastructure(services);
        return services;
    }
    
    private static void SetupCore(IServiceCollection services)
    {
        services.AddScoped<IEquipmentService, EquipmentService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IProblemService, ProblemService>();
        services.AddScoped<ITouristEquipmentService, TouristEquipmentService>();
        services.AddScoped<IPreferenceService, PreferenceService>();
        services.AddScoped<ITourService, TourService>();
        services.AddScoped<IEquipmentManagmentService, EquipmentManagmentService>();
        services.AddScoped<IObjectService, ObjectService>();
        services.AddScoped<ITouristPositionService, TouristPositionService>();
        services.AddScoped<IPublicRegistrationRequestService, PublicRegistrationRequestService>();
        services.AddScoped<ITourExecutionService, TourExecutionService>();
        services.AddScoped<ITourPurchaseTokenService, TourPurchaseTokenService>();
    }

    private static void SetupInfrastructure(IServiceCollection services)
    {
        services.AddScoped(typeof(ICrudRepository<Equipment>), typeof(CrudDatabaseRepository<Equipment, ToursContext>));
        services.AddScoped(typeof(ICrudRepository<ShoppingCart>), typeof(CrudDatabaseRepository<ShoppingCart, ToursContext>));
        services.AddScoped(typeof(ICrudRepository<Problem>), typeof(CrudDatabaseRepository<Problem, ToursContext>));
        services.AddScoped(typeof(ICrudRepository<TouristEquipment>), typeof(CrudDatabaseRepository<TouristEquipment, ToursContext>));
        services.AddScoped(typeof(ICrudRepository<Preference>), typeof(CrudDatabaseRepository<Preference, ToursContext>));
        services.AddScoped(typeof(ICrudRepository<Tour>), typeof(JsonCrudRepo<Tour, ToursContext>));
        services.AddScoped(typeof(ICrudRepository<EquipmentManagment>), typeof(CrudDatabaseRepository<EquipmentManagment, ToursContext>));
        services.AddScoped(typeof(ICrudRepository<TourExecution>), typeof(JsonCrudRepo<TourExecution, ToursContext>));
        services.AddScoped(typeof(ICrudRepository<Object>), typeof(CrudDatabaseRepository<Object, ToursContext>));
        services.AddScoped(typeof(ICrudRepository<PublicRegistrationRequest>), typeof(CrudDatabaseRepository<PublicRegistrationRequest, ToursContext>));
        services.AddScoped(typeof(ICrudRepository<TouristPosition>), typeof(CrudDatabaseRepository<TouristPosition, ToursContext>));
        services.AddScoped(typeof(ICrudRepository<TourPurchaseToken>), typeof(CrudDatabaseRepository<TourPurchaseToken, ToursContext>));
        services.AddScoped(typeof(IPreferenceRepository), typeof(PreferenceRepository));
        services.AddScoped(typeof(IObjectRepository), typeof(ObjectRepository));
        services.AddScoped(typeof(IPublicRegistrationRequestRepository), typeof(PublicRegistrationRequestRepository));
        services.AddScoped(typeof(ITourExecutionRepository), typeof(TourExecutionRepository));
        services.AddScoped(typeof(IOrderRepository), typeof(OrderRepository));
        services.AddScoped(typeof(ITourPurchaseTokenRepository), typeof(TourPurchaseTokenRepository));

        services.AddDbContext<ToursContext>(opt =>
            opt.UseNpgsql(DbConnectionStringBuilder.Build("tours"),
                x => x.MigrationsHistoryTable("__EFMigrationsHistory", "tours")));
    }
}