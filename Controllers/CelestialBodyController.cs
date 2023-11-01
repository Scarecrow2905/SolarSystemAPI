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

    
    [HttpGet("{name}")]
    public IActionResult GetCelestialBody(string name)
    {
        var celestialBody = _celestialBodyService.GetCelestialBodyByName(name);

        if (celestialBody == null)
        {
            return NotFound();
        }
        
        return Ok(celestialBody);
    }

    [HttpGet("{id}")]
    public IActionResult GetCelestialBodyById(string id)
    {
        var celestialBody = _celestialBodyService.GetCelestialBodyById(id);
        if (celestialBody == null)
            return NotFound();

        return Ok(celestialBody);
    }

    [HttpPost]
    public IActionResult CreateCelestialBody([FromBody] CelestialBody body)
    {
        try
        {
            var createdBody = _celestialBodyService.CreateCelestialBody(body);
            return CreatedAtAction(nameof(GetCelestialBodyById), new { id = createdBody.Id }, createdBody);
        }
        catch (Exception exception)
        {
            // Handle exceptions, log, and return an appropriate response
            return BadRequest(exception.Message);
        }
    }
}