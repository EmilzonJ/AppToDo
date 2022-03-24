using dotenv.net;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.Persistence;

public class AppDataContextFactory : IDesignTimeDbContextFactory<AppDataContext>
{
    public AppDataContextFactory()
    {
    }

    public AppDataContext CreateDbContext(string[] args)
    {
        DotEnv.Load(new DotEnvOptions(true, new[]
        {
            "..//.//Api//.env"
        }));

        var builder = new DbContextOptionsBuilder<AppDataContext>();
        var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION");
        if (connectionString != null)
        {
            builder.UseSqlServer(connectionString);
        }

        return new AppDataContext(builder.Options);
    }
}