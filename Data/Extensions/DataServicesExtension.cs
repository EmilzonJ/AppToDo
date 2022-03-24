using Data.Persistence;
using Data.Repositories;
using Domain.Repositories;
using dotenv.net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Extensions;

public static class DataServicesExtension
{
    public static IServiceCollection AddDataLayerServices(this IServiceCollection services)
    {
        DotEnv.Load(new DotEnvOptions(true, new[]
        {
            "..//.//Api//.env"
        }));

        var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION");
        services.AddHttpContextAccessor();
        services.AddDbContext<AppDataContext>(options =>
        {
            if (connectionString != null)
                options
                    .UseLazyLoadingProxies()
                    .UseSqlServer(connectionString);
        });
        
        services.AddScoped(typeof(IRepositoryBase<,>), typeof(RepositoryBase<,>));

        return services;
    }
}