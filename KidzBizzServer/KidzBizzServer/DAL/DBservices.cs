using KidzBizzServer.BL;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AIPlayerController : ControllerBase
{
    private readonly AIPlayerService _aiPlayerService;

    public AIPlayerController(AIPlayerService aiPlayerService)
    {
        _aiPlayerService = aiPlayerService;
    }

    // GET: api/AIPlayer/decision
    // Assuming that a decision ID or similar parameter is needed to fetch a specific decision
    [HttpGet("decision/{id}")]
    public ActionResult<string> GetDecision(int id)
    {
        try
        {
            var decision = _aiPlayerService.GetDecision(id); // Assuming GetDecision(int id) exists
            return Ok(decision);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred while retrieving the decision: {ex.Message}");
        }
    }

    // POST: api/AIPlayer/execute
    [HttpPost("execute")]
    public IActionResult ExecuteDecision([FromBody] GameState gameState)
    {
        try
        {
            if (gameState == null)
            {
                return BadRequest("Invalid game state provided.");
            }

            var result = _aiPlayerService.ExecuteDecision(gameState);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }
}
