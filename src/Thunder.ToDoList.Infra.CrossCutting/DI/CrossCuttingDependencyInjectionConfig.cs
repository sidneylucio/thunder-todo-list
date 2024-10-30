using Microsoft.Extensions.DependencyInjection;
using Thunder.ToDoList.Infra.CrossCutting.Logging;

namespace Thunder.ToDoList.Infra.CrossCutting.DI;

public static class CrossCuttingDependencyInjectionConfig
{
    public static IServiceCollection AddCrossCuttingServices(this IServiceCollection services)
    {
        services.AddSingleton<ILoggerManager, LoggerManager>();

        return services;
    }
}
