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

    [HttpGet]
    public IActionResult GetCelestialBodies()
    {
        var celestialBodies = _celestialBodyService.GetCelestialBodies();
        return Ok(celestialBodies);
    }

    [HttpGet("{name}")]
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