using SolarSystemAPI.Models;

namespace SolarSystemAPI.Services;
using Microsoft.Extensions.DependencyInjection;

// NOT TO BE USED
// Only later if wanting to add another Collcetion in the database
public class SeedingService
{
    
    private readonly IMongoDbContext _dbContext;
    private List<CelestialBody> CelestialBodies;

    public SeedingService(IMongoDbContext dbContext)
     {
         
         _dbContext = dbContext;

         CelestialBodies = new List<CelestialBody>
         {
             new() { Name = "Mercury", Mass = 3.285E23, DistanceFromSun = 57.9E6, Diameter = 4.88E3 },
             new() { Name = "Venus", Mass = 4.867E24, DistanceFromSun = 108.2E6, Diameter = 12.1E3 },
             new() { Name = "Earth", Mass = 5.972E24, DistanceFromSun = 149.6E6, Diameter = 12.742E3 },
             new() { Name = "Mars", Mass = 6.417E23, DistanceFromSun = 227.9E6, Diameter = 6.779E3 },
             new() { Name = "Jupiter", Mass = 1.898E27, DistanceFromSun = 778.3E6, Diameter = 139.8E3 },
             new() { Name = "Saturn", Mass = 5.683E26, DistanceFromSun = 1.429E9, Diameter = 116.5E3 },
             new() { Name = "Uranus", Mass = 8.681E25, DistanceFromSun = 2.871E9, Diameter = 50.7E3 },
             new() { Name = "Neptune", Mass = 1.024E26, DistanceFromSun = 4.498E9, Diameter = 49.2E3 }
         };
     }
    
     public void SeedDatabase()
     {
         try
         {
             Console.WriteLine("Seeding Database...");
             
             _dbContext.InsertInitialData(CelestialBodies);
             
             Console.WriteLine("Seed complete!");
         }
         catch (Exception ex)
         {
             Console.WriteLine($"Error during database seeding: {ex.Message}");
         }
    
     }
}
