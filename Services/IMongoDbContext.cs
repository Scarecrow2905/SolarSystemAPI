using MongoDB.Driver;

namespace SolarSystemAPI.Services;

public interface IMongoDbContext
{
    IMongoCollection<T> GetCollection<T>(string name);
}