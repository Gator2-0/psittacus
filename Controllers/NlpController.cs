using Microsoft.AspNetCore.Mvc;
using psittacus.Services;

[ApiController]
[Route("api/[controller]")]
public class NlpController : ControllerBase
{
    private readonly NlpService _nlpService;

    public NlpController(NlpService nlpService)
    {
        _nlpService = nlpService;
    }

    [HttpPost("process-query")]
    public IActionResult ProcessQuery([FromBody] string query)
    {
        var result = _nlpService.ProcessQuery(query);
        return Ok(result);
    }
}
