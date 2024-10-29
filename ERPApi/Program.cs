using Microsoft.EntityFrameworkCore;
using TechtivaERPApi.Models;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder);
var app = builder.Build();

ConfigureMiddleware(app);
app.Run();

/// <summary>
/// Configures the necessary services for the application.
/// </summary>
/// <param name="builder">The application builder used to configure services.</param>
void ConfigureServices(WebApplicationBuilder builder)
{
    var connectionString = builder.Configuration.GetConnectionString("ERPDatabase");

    if (string.IsNullOrEmpty(connectionString))
    {
        throw new InvalidOperationException("Connection string 'ERPDatabase' not found.");
    }

    var serverVersion = new MySqlServerVersion(new Version(8, 0, 23));
    builder.Services.AddDbContext<ERPContext>(options =>
        options.UseMySql(connectionString, serverVersion));

    builder.Services.AddControllers();
    builder.Services.AddRazorPages();
}

/// <summary>
/// Configures the middleware pipeline for the application.
/// </summary>
/// <param name="app">The web application to configure.</param>
void ConfigureMiddleware(WebApplication app)
{
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();
    app.UseAuthorization();

    app.MapControllers();
    app.MapRazorPages();
}
