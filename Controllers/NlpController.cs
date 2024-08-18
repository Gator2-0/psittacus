using Microsoft.AspNetCore.Mvc;
using psittacus.Services;

[ApiController]
[Route("[controller]")]
public class NlpController : ControllerBase
{
    private readonly NlpService _nlpService;

    public NlpController(NlpService nlpService)
    {
        _nlpService = nlpService;
    }

    [HttpPost("process-query")]
    public async Task<IActionResult> ProcessQuery([FromBody] string query)
    {
        Console.WriteLine("API controller query: " + query);
        var result = await _nlpService.ProcessQuery(query);
        Console.WriteLine(result);
        return Ok(result);
    }
}
