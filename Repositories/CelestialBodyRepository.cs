using MongoDB.Bson;
using MongoDB.Driver;
using SolarSystemAPI.Models;
using SolarSystemAPI.Services;

namespace SolarSystemAPI.Repositories;

// Class that handles the interaction with the database
public class CelestialBodyRepository : ICelestialBodyRepository
{
    private readonly MongoDbContext _context;

    public CelestialBodyRepository(MongoDbContext context)
    {
        _context = context;
    }

    // GET
    public IMongoCollection<CelestialBody> RepositoryGetCelestialBodyCollection()
    {
        return _context.GetCollection<CelestialBody>("celestialBodies");
    }
    
    // Get by Name
    public CelestialBody RepositoryGetCelestialBodyByName(string name)
    {
        var collection = RepositoryGetCelestialBodyCollection();
        return collection.Find(body => body.Name == name).FirstOrDefault();
    }

    public CelestialBody RepositoryGetCelestialBodyById(string id)
    {
        var collection = RepositoryGetCelestialBodyCollection();
        var filter = Builders<CelestialBody>.Filter.Eq("_id", ObjectId.Parse(id));
        return collection.Find(filter).FirstOrDefault();
    }
    
    // Add methods for Create, Update, and Delete operations
    // CREATE

    public CelestialBody RepositoryCreateCelestialBody(CelestialBody body)
    {
        var collection = RepositoryGetCelestialBodyCollection();
        collection.InsertOne(body);
        return body;
    }

    public CelestialBody RepositoryUpdateCelestialBody(CelestialBody body)
    {
        throw new NotImplementedException();
    }

    public CelestialBody RepositoryDeleteCelestialBody(CelestialBody body)
    {
        throw new NotImplementedException();
    }
}