using MongoDB.Driver;
using SolarSystemAPI.Models;

namespace SolarSystemAPI.Services;

public interface IMongoDbContext
{
    IMongoCollection<T> GetCollection<T>(string name);
    IMongoCollection<CelestialBody> CelestialBodies { get; }
    void InsertInitialData(List<CelestialBody> data);
}