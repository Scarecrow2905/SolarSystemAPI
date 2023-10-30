namespace SolarSystemAPI.Services;
using Microsoft.Extensions.DependencyInjection;

// NOT TO BE USED
// Only later if wanting to add another Collcetion in the database
public class SeedingService
{
    private readonly ICelestialBodyService _celestialBodyService;
    private readonly IMongoDbContext _dbContext;

    public SeedingService(ICelestialBodyService celestialBodyService, IMongoDbContext dbContext)
    {
        _celestialBodyService = celestialBodyService;
        _dbContext = dbContext;
    }
    
    public void SeedDatabase()
    {
        try
        {
            Console.WriteLine("Seeding Database...");
            
            var initialData = _celestialBodyService.GetCelestialBodies();
            _dbContext.InsertInitialData(initialData);
            
            Console.WriteLine("Seed complete!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during database seeding: {ex.Message}");
        }

    }
}
