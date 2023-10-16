using Explorer.Stakeholders.Core.Mappers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.UseCases;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Stakeholders.Infrastructure.Database;

namespace Explorer.Stakeholders.Infrastructure;

public static class AppRatingStartup
{
    public static IServiceCollection ConfigureAppRatingsModule(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AppRatingProfile).Assembly);
        SetupCore(services);
        SetupInfrastructure(services);
        return services;
    }

    private static void SetupCore(IServiceCollection services)
    {
        services.AddScoped<IAppRatingService, AppRatingService>();
    }

    private static void SetupInfrastructure(IServiceCollection services)
    {
        services.AddScoped(typeof(ICrudRepository<AppRating>), typeof(CrudDatabaseRepository<AppRating, StakeholdersContext>));

        services.AddDbContext<StakeholdersContext>(opt =>
            opt.UseNpgsql(DbConnectionStringBuilder.Build("appRatings"),
                x => x.MigrationsHistoryTable("__EFMigrationsHistory", "appRatings")));
    }
}