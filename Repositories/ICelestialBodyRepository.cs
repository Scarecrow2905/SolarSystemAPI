using SolarSystemAPI.Models;
using MongoDB.Driver;

namespace SolarSystemAPI.Services;

public interface ICelestialBodyRepository
{
    // Add methods for Create, Update, and Delete operations
    IMongoCollection<CelestialBody> RepositoryGetCelestialBodyCollection();
    CelestialBody RepositoryGetCelestialBodyByName(string name);
    CelestialBody RepositoryGetCelestialBodyById(string id);

    CelestialBody RepositoryCreateCelestialBody(CelestialBody body);
    void RepositoryUpdateCelestialBody(string id, CelestialBody body);
    void RepositoryDeleteCelestialBody(string id);

}