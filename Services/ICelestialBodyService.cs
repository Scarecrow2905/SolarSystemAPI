using SolarSystemAPI.Models;

namespace SolarSystemAPI.Services;

public interface ICelestialBodyService
{
    List<CelestialBody> GetCelestialBodies();
    CelestialBody GetCelestialBodyByName(string name);
    CelestialBody GetCelestialBodyById(string id);
    CelestialBody CreateCelestialBody(CelestialBody body);
    void UpdateCelestialBody(string name, CelestialBody updatedBody);
    void DeleteCelestialBody(string id);

}