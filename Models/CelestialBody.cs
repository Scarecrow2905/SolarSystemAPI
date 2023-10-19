namespace SolarSystemAPI.Models;

public class CelestialBody
{
    public string Name { get; set; }
    public double Diameter { get; set; }
    public double Mass { get; set; } // Mass in kilograms
    public double DistanceFromSun { get; set; } // Earth is approximately 1 AU from the Sun
    
}