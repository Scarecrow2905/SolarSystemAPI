using SolarSystemAPI.Models;

namespace SolarSystemAPI.Services;

public interface ICelestialBodyService
{
    List<CelestialBody> GetCelestialBodies();
    CelestialBody GetCelestialBodyByName(string name);
    CelestialBody GetCelestialBodyById(string id);
    CelestialBody CreateCelestialBody(CelestialBody body);
    CelestialBody UpdateCelestialBody(string name, CelestialBody updatedBody);
    CelestialBody DeleteCelestialBody(string name);

}