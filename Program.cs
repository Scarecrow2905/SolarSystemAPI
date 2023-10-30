using SolarSystemAPI.Services;
using SolarSystemAPI.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<ICelestialBodyService, CelestialBodyService>();
builder.Services.AddSingleton<IMongoDbContext, MongoDbContext>();

// Kept in case of seeding another collection to DB
// builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDB"));
// builder.Services.AddSingleton<IMongoDbContext, MongoDbContext>();


builder.Services.AddTransient<SeedingService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseStaticFiles();
app.UseDirectoryBrowser();

app.MapGet("/", () =>
{
    return Results.File("wwwroot/index.html", "text/html");
});

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
// Seed Database, one use only needed-----!!!!
// var seedingService = app.Services.GetRequiredService<SeedingService>();
// seedingService.SeedDatabase();
// ---------------------------------------!!!!


app.Run();