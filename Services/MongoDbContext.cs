using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SolarSystemAPI.Models;
using SolarSystemAPI.Settings;

namespace SolarSystemAPI.Services;

public class MongoDbContext : IMongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IOptions<MongoDBSettings> settings)
    {
        // if (configuration == null)
        // {
        //     throw new ArgumentNullException(nameof(configuration));
        // }
        
        // var connectionString = configuration.GetConnectionString("MongoDB:ConnectionString");
        // var databaseName = configuration["MongoDB:DatabaseName"];
        //
        // var client = new MongoClient(connectionString);
        // _database = client.GetDatabase(databaseName);
        
       
            var connectionString = settings.Value.ConnectionString;
            var databaseName = settings.Value.DatabaseName;

            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);


    }

    public IMongoCollection<T> GetCollection<T>(string name)
    {
        return _database.GetCollection<T>(name);
    }


    public IMongoCollection<CelestialBody> CelestialBodies
    {
        get { return _database.GetCollection<CelestialBody>("celestialBodies"); }
    }
    public void InsertInitialData(List<CelestialBody> data)
    {
        CelestialBodies.InsertMany(data);
    }
    
}