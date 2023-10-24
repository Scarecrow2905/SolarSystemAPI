using SolarSystemAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICelestialBodyService, CelestialBodyService>();
builder.Services.AddSingleton<IMongoDbContext, MongoDbContext>();

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

app.Run();