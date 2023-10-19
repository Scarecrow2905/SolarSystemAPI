using SolarSystemAPI.Models;

namespace SolarSystemAPI.Services;

public class CelestialBodyService : ICelestialBodyService
{

    private readonly List<CelestialBody> _celestialBodies;

    public CelestialBodyService()
    {
        // Initialize celestial bodies (mock data for now)
        _celestialBodies = new List<CelestialBody>
        {
            new()
            {
                Name = "Mercury",
                Diameter = 4879.0, // Kilometers 
                Mass = 3.3011e23, // Kilograms
                DistanceFromSun = 0.39 // Astronomical units
            },
            new()
            {
                Name = "Venus",
                Diameter = 4879.0, // Kilometers 
                Mass = 3.3011e23, // Kilograms
                DistanceFromSun = 0.39 // Astronomical units
            },
            new()
            {
                Name = "Earth",
                Diameter = 12742.0, // Kilometers 
                Mass = 5.9722e24, // Kilograms
                DistanceFromSun = 1.0 // Astronomical units
            },
            new()
            {
                Name = "Mars",
                Diameter = 6779.0, // Kilometers 
                Mass = 6.4171e23, // Kilograms
                DistanceFromSun = 1.52 // Astronomical units
            },
            new()
            {
                Name = "Jupiter",
                Diameter = 139820.0, // Kilometers 
                Mass = 1.898e27, // Kilograms
                DistanceFromSun = 5.2 // Astronomical units
            },
            new()
            {
                Name = "Saturn",
                Diameter = 116460.0, // Kilometers 
                Mass = 5.683e26, // Kilograms
                DistanceFromSun = 9.58 // Astronomical units
            },
            new()
            {
                Name = "Uranus",
                Diameter = 50724.0, // Kilometers
                Mass = 8.681e25, // Kilograms
                DistanceFromSun = 19.22 // Astronomical units
            },
            new()
            {
                Name = "Neptune",
                Diameter = 49244.0, // Kilometers
                Mass = 1.024e26, // Kilograms
                DistanceFromSun = 30.05 // Astronomical units
            },
            new()
            {
                Name = "Pluto",
                Diameter = 2376.0, // Kilometers
                Mass = 1.303e22, // Kilograms
                DistanceFromSun = 39.48 // Astronomical units
            },
        };
    }
    public List<CelestialBody> GetCelestialBodies()
    {
        return _celestialBodies;
    }

    public CelestialBody GetCelestialBodyByName(string name)
    {
        return _celestialBodies.FirstOrDefault(body => body.Name.ToLower() == name.ToLower()) ?? throw new InvalidOperationException("Error message");
    }
}