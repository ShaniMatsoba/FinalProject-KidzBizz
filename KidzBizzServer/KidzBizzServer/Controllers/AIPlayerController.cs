using KidzBizzServer.BL;
using Microsoft.AspNetCore.Mvc;
using System;

namespace KidzBizzServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AIPlayerController : ControllerBase
    {
        private readonly AIPlayerService _aiPlayerService;

        public AIPlayerController(AIPlayerService aiPlayerService)
        {
            _aiPlayerService = aiPlayerService;
        }

        [HttpGet("decision")]
        public ActionResult<string> GetDecision()
        {
            try
            {
                var decision = _aiPlayerService.MakeDecision();
                return Ok(decision);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while making a decision: {ex.Message}");
            }
        }

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
}
