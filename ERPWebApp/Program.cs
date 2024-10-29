var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

ConfigureMiddleware(app);

app.Run();

/// <summary>
/// Configures services for the application.
/// </summary>
/// <param name="services">The service collection to add services to.</param>
/// <param name="configuration">The application configuration.</param>
void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    var apiBaseUrl = configuration["ApiSettings:BaseUrl"];
    if (string.IsNullOrEmpty(apiBaseUrl))
    {
        throw new InvalidOperationException("API base URL is not configured. Please check 'ApiSettings:BaseUrl' in appsettings.json.");
    }

    // Add services to the container
    services.AddControllersWithViews();
    services.AddHttpClient();
}

/// <summary>
/// Configures the middleware pipeline for the application.
/// </summary>
/// <param name="app">The web application to configure.</param>
void ConfigureMiddleware(WebApplication app)
{
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();
    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
}
