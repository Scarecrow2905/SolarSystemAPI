using Microsoft.AspNetCore.Mvc;
using SolarSystemAPI.Services;

namespace SolarSystemAPI.Controllers;

[ApiController]
[Route("api/celestialbody")] // Base route for all actions in this controller
public class CelestialBodyController : ControllerBase
{
    private readonly ICelestialBodyService _celestialBodyService;

    public CelestialBodyController(ICelestialBodyService celestialBodyService)
    {
        _celestialBodyService = celestialBodyService;
    }


    [HttpGet("planets")] // Endpoint to get the list of planets
    public IActionResult GetCelestialBodies()
    {
        var planets = _celestialBodyService.GetCelestialBodies();
        return Ok(planets);
    }

    [HttpGet("{name}")]
    public IActionResult GetEarthDetails(string name)
    {
        var celestialBodyDetails = _celestialBodyService.GetCelestialBodyByName(name);
        if (celestialBodyDetails == null)
        {
            return NotFound($"{name} was not found.");
        }

        return Ok(celestialBodyDetails);
    }
}