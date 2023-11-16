using Microsoft.AspNetCore.Mvc;
using SolarSystemAPI.Models;
using SolarSystemAPI.Services;


namespace SolarSystemAPI.Controllers;

[ApiController]
[Route("api/[controller]")] 
public class CelestialBodyController : ControllerBase
{
    private readonly ICelestialBodyService _celestialBodyService;
    
    public CelestialBodyController(ICelestialBodyService celestialBodyService)
    {
        _celestialBodyService = celestialBodyService;
    }
    
    /// <summary>
    /// Get information about all the planets in our solarsystem.
    /// </summary>
    /// <returns>celestialBodies: List of celestial bodies</returns>
    [HttpGet]
    [ProducesResponseType(typeof(CelestialBody), 200)]
    [ProducesResponseType(404)]
    public IActionResult GetCelestialBodies()
    {
        var celestialBodies = _celestialBodyService.GetCelestialBodies();
        return Ok(celestialBodies);
    }

    /// <summary>
    /// Returns one planet based on the name
    /// </summary>
    /// <param name="name"></param>
    /// <returns>celestialBody: A single planet based on the name</returns>
    [HttpGet("{name}")]
    [ProducesResponseType(typeof(CelestialBody), 200)]
    [ProducesResponseType(404)]
    public IActionResult GetCelestialBodyByName(string name)
    {
        var celestialBody = _celestialBodyService.GetCelestialBodyByName(name);
        if (celestialBody == null)
        {
            return NotFound();
        }
        return Ok(celestialBody);
    }
}