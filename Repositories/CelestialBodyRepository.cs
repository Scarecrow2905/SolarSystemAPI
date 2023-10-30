using MongoDB.Driver;
using SolarSystemAPI.Models;
using SolarSystemAPI.Services;

namespace SolarSystemAPI.Repositories;

public class CelestialBodyRepository : ICelestialBodyRepository
{
    private readonly MongoDbContext _context;

    public CelestialBodyRepository(MongoDbContext context)
    {
        _context = context;
    }

    public IMongoCollection<CelestialBody> GetCelestialBodyCollection()
    {
        return _context.GetCollection<CelestialBody>("celestialBodies");
    }

    // Implement CRUD operations if needed
    // Get by Name
    public CelestialBody GetCelestialBodyByName(string name)
    {
        var collection = GetCelestialBodyCollection();
        return collection.Find(body => body.Name == name).FirstOrDefault();
    }
    
    // Add methods for Create, Update, and Delete operations
}