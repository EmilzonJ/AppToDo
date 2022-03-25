using Data.Extensions;
using Microsoft.OpenApi.Models;

namespace Api;

public static class Startup
{
    public static WebApplication InitializeApp(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        ConfigureServices(builder);
        var app = builder.Build();
        Configure(app);
        return app;
    }

    private static void ConfigureServices(WebApplicationBuilder builder)
    {
        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "ToDo API",
                Description = "An ASP.NET Core Web API for managing ToDo items",
            }));

        // Add Infrastructure Layer Services
        builder.Services.AddDataLayerServices();
    }

    private static void Configure(WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
    }
}