using AspNetCoreRateLimit;
using Microsoft.OpenApi.Models;
using SolarSystemAPI.Repositories;
using SolarSystemAPI.Services;
using SolarSystemAPI.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IMongoDbContext, MongoDbContext>();
builder.Services.AddScoped<ICelestialBodyRepository, CelestialBodyRepository>();
builder.Services.AddScoped<ICelestialBodyService, CelestialBodyService>();

// Kept in case of seeding another collection to DB
builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDB"));

// Rate limiting configuration
builder.Services.AddMemoryCache(); // This line adds the memory cache service, which is used by the rate limiter to store IP policies and counters in-memory. 
builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting")); // This line configures the 'IpRateLimitOptions' using the values from "IpRateLimiting" section of my configuration. 
builder.Services.Configure<IpRateLimitPolicies>(builder.Configuration.GetSection("IpRateLimitPolicies")); // The IpRateLimitPolicies class holds the rules for rate limiting, such as the period, limit and endpoint
builder.Services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>(); // The IIpPolicyStore interface is responsible for storing and retrieving IP policies (rules) for rate limiting. The class uses the memory chache to store these policies.
builder.Services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>(); // The interface is responsible for storing and retrieving counters(request counts) 
builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>(); // The RateLimitConfiguration implementation holds the configuration values for the rate limiter
// In summary, these lines set up the necessary services and configurations for rate limiting using the AspNetCoreRateLimit library.
// The library uses memory cache to store IP policies and counters,
// and these registrations ensure that the necessary components are available for rate limiting to function.


//builder.Services.AddTransient<SeedingService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Solar System API", Version = "v1"});
});


try
{
    var app = builder.Build();
    
    // Configure the HTTP request pipeline.
    app.UseStaticFiles();
    app.UseDirectoryBrowser();

    app.MapGet("/frontEnd", () => { return Results.File("wwwroot/index.html", "text/html"); });

    // Sidenote: Might delete the if statement to show documentation in public
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers(); // Looks for any controllers to use, for example CelestialBodyController.cs

// No need to run this anymore now that DB is populated, but kept in case more seeding is needed.
//Seed Database, one use only needed-----!!!!
// var seedingService = app.Services.GetRequiredService<SeedingService>();
// seedingService.SeedDatabase();
// --------------------------------------!!!!

    app.Run();

}

catch (Exception exception)
{
    Console.WriteLine($"Error building application: {exception}");
    throw;
}