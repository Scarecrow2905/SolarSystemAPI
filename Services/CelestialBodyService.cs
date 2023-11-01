using MongoDB.Driver;
using SolarSystemAPI.Models;
using SolarSystemAPI.Repositories;

namespace SolarSystemAPI.Services;

public class CelestialBodyService : ICelestialBodyService
{

    private readonly CelestialBodyRepository _celestialBodyRepository;
    
    // Constructor:
    public CelestialBodyService(CelestialBodyRepository celestialBodyRepository)
    {
        _celestialBodyRepository = celestialBodyRepository;
    }

    public List<CelestialBody> GetCelestialBodies()
    {
        var collection = _celestialBodyRepository.RepositoryGetCelestialBodyCollection(); // Make this in CelestialBodyRepository
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

    public CelestialBody UpdateCelestialBody(string name, CelestialBody body)
    {
        throw new Exception();
    }

    public CelestialBody DeleteCelestialBody(string name)
    {
        throw new Exception();
    }
    
    

}