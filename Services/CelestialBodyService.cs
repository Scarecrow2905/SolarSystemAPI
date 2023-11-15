using MongoDB.Driver;
using SolarSystemAPI.Models;
using SolarSystemAPI.Repositories;

namespace SolarSystemAPI.Services;

public class CelestialBodyService : ICelestialBodyService
{

    private readonly ICelestialBodyRepository _celestialBodyRepository;
    
    // Constructor:
    public CelestialBodyService(ICelestialBodyRepository celestialBodyRepository)
    {
        _celestialBodyRepository = celestialBodyRepository;
    }

    public List<CelestialBody> GetCelestialBodies()
    {
        var collection = _celestialBodyRepository.RepositoryGetCelestialBodyCollection();
        return collection.AsQueryable().ToList();
    }

    public CelestialBody GetCelestialBodyByName(string name)
    {
        return _celestialBodyRepository.RepositoryGetCelestialBodyByName(name);
    }

    public CelestialBody GetCelestialBodyById(string id)
    {
        return _celestialBodyRepository.RepositoryGetCelestialBodyById(id);
    }
    public CelestialBody CreateCelestialBody(CelestialBody body)
    {
        return _celestialBodyRepository.RepositoryCreateCelestialBody(body);
    }

    public void UpdateCelestialBody(string id, CelestialBody updatedBody)
    {
        _celestialBodyRepository.RepositoryUpdateCelestialBody(id, updatedBody);
    }

    public void DeleteCelestialBody(string id)
    {
        _celestialBodyRepository.RepositoryDeleteCelestialBody(id);
    }
}