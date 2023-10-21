using API.Register;
using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.RegisterServices();

    Log.Information("Starting up");
    var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", false, true)
        .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", true,
            true)
        .Build();

    SerilogService.GetInitialize(configuration);

    builder.Host.UseSerilog();

    var app = builder.Build();

    app.UseSwagger(options => options.RouteTemplate = "swagger/{documentName}/swagger.json");
    app.UseSwaggerUI(options =>
    {
        options.DocumentTitle = "VpBank Service API";
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "VpBank API v1");
        options.SwaggerEndpoint("/swagger/v2/swagger.json", "VpBank API v2");
    });

    app.UseHttpsRedirection();

    app.UseCors();

    app.UseSerilogRequestLogging();

    app.UseHttpsRedirection();

    app.UseAuthentication();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)when (
    ex.GetType().Name is not "StopTheHostException"
    && ex.GetType().Name is not "HostAbortedException"
)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}