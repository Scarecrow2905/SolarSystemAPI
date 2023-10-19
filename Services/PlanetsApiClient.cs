using System.Net.Http;
using System.Threading.Tasks;

namespace SolarSystemAPI.Services;

public class PlanetsApiClient
{
    private readonly HttpClient _httpClient;

    public PlanetsApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
}