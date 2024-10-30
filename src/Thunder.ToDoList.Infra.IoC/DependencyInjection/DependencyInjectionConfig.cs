using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Thunder.ToDoList.Domain.Interfaces;
using Thunder.ToDoList.Infra.Data.Context;
using Thunder.ToDoList.Infra.Data.Repositories;
using Thunder.ToDoList.Infra.CrossCutting.DI;
using Thunder.ToDoList.Application.Handlers;

namespace Thunder.ToDoList.Infra.IoC.DependencyInjection;

public static class DependencyInjectionConfig
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(GetAllTaskItemsQueryHandler).Assembly);
        });

        services.AddCrossCuttingServices();

        return services;
    }

    public static IServiceCollection AddDataDependencies(this IServiceCollection services, string databaseName)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseInMemoryDatabase(databaseName));

        services.AddScoped<ITaskItemRepository, TaskItemRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}
