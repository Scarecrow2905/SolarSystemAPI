using MongoDB.Driver;
using SolarSystemAPI.Models;
using SolarSystemAPI.Services;

namespace SolarSystemAPI.Repositories;

public class CelestialBodyRepository
{
    private readonly MongoDbContext _context;

    public CelestialBodyRepository(MongoDbContext context)
    {
        _context = context;
    }

    public IMongoCollection<CelestialBody> GetCelestialBody()
    {
        return _context.GetCollection<CelestialBody>("celestialBodies");
    }
}