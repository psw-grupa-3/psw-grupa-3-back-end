using Explorer.Stakeholders.Infrastructure;
using Explorer.Tours.Infrastructure;
using Explorer.Blog.Infrastructure;

namespace Explorer.API.Startup;

public static class ModulesConfiguration
{
    public static IServiceCollection RegisterModules(this IServiceCollection services)
    {
        services.ConfigureStakeholdersModule();
        services.ConfigureBlogModule();
        services.ConfigureToursModule();

        return services;
    }
}