using System.Text.Json;
using Api.Database;
using Api.Database.Seeders;
using Api.Services;
using FastEndpoints.Security;
using Microsoft.EntityFrameworkCore;

var bld = WebApplication.CreateBuilder();
var config = bld.Configuration;

// Configure services
bld.Services.AddDbContext<ApiDbContext>(options =>
    options.UseNpgsql(config.GetConnectionString("DefaultConnection"))
);

bld.Services.AddSingleton<IUserService, UserService>();
bld.Services.AddSpaStaticFiles(o => o.RootPath = "dist");

// Configure authentication, authorization and FastEndpoints
bld.Services.AddAuthenticationCookie(validFor: TimeSpan.FromMinutes(10))
    .AddAuthorization()
    .AddFastEndpoints();

var app = bld.Build();

// Run args seed the database
if (args.Length > 0 && args[0] == "seed")
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<ApiDbContext>();
    UsersSeeder.Seed(db);
    Environment.Exit(0);
}

// authentication and authorization middleware must be used before FastEndpoints middleware
app.UseRouting();
app.UseAuthentication()
    .UseAuthorization()
    .UseFastEndpoints(o =>
    {
        o.Endpoints.RoutePrefix = "api";
        o.Serializer.Options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });
app.UseEndpoints(_ => { });

// Spa fallback
app.UseSpaStaticFiles();
app.UseSpa(x =>
{
    if (!app.Environment.IsDevelopment())
        return;
    x.UseProxyToSpaDevelopmentServer("http://localhost:5101");
});

// Run the application
app.Run();
