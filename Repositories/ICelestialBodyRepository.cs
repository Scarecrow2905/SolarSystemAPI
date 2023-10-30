using SolarSystemAPI.Models;
using MongoDB.Driver;

namespace SolarSystemAPI.Services;

public interface ICelestialBodyRepository
{
    IMongoCollection<CelestialBody> GetCelestialBodyCollection();
    CelestialBody GetCelestialBodyByName(string name);
}