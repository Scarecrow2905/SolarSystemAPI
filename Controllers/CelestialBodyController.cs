using Microsoft.AspNetCore.Mvc;
using SolarSystemAPI.Models;
using SolarSystemAPI.Repositories;


namespace SolarSystemAPI.Controllers;

[ApiController]
[Route("api/[controller]")] 
public class CelestialBodyController : ControllerBase
{
    //private readonly ICelestialBodyService _celestialBodyService;
    private readonly CelestialBodyRepository _celestialBodyRepository;

    public CelestialBodyController(CelestialBodyRepository celestialBodyRepository)
    {
        _celestialBodyRepository = celestialBodyRepository;
    }

    
    [HttpGet("{name}")]
    public IActionResult GetCelestialBody(string name)
    {
        var celestialBody = _celestialBodyRepository.GetCelestialBodyByName(name);

        if (celestialBody == null)
        {
            return NotFound();
        }
        
        return Ok(celestialBody);
    }

    [HttpPost]
    public IActionResult AddCelestialBody([FromBody] CelestialBody celestialBody)
    {
        // Perform any validation or business logic as needed
        
        // Add the celestial body to the repository
        // May want to handle the result of the addition and return appropriate responses
        
        //_celestialBodyRepository.AddCelestialBody(celestialBody);

        return Ok("Celestial body added successfully");
    }
}