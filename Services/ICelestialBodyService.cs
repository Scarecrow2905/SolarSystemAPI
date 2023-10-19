using SolarSystemAPI.Models;

namespace SolarSystemAPI.Services;

public interface ICelestialBodyService
{
    List<CelestialBody> GetCelestialBodies();
    CelestialBody GetCelestialBodyByName(string name);

}