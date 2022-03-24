using Api;
using Data.Persistence;
using Microsoft.EntityFrameworkCore;

var app = Startup.InitializeApp(args);

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var context = services.GetRequiredService<AppDataContext>();
        context.Database.Migrate();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred migrating the DB.");
    }
}

app.Run();