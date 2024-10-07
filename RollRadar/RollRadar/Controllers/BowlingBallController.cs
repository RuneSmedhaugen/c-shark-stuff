using Microsoft.AspNetCore.Mvc;
using RollRadar.Models;

[ApiController]
[Route("api/[controller]")]
public class BowlingBallController : ControllerBase
{
    private readonly BowlingBallService _bowlingBallService;

    public BowlingBallController(BowlingBallService bowlingBallService)
    {
        _bowlingBallService = bowlingBallService;
    }

    [HttpGet]
    public IActionResult GetAllBalls()
    {
        var balls = _bowlingBallService.ViewAllBowlingBalls();
        return Ok(balls);
    }

    [HttpPost]
    public IActionResult AddBall([FromBody] BowlingBalls ball)
    {
        _bowlingBallService.AddBowlingBall(ball.UserId);
        return Ok("Bowling ball added.");
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBall(int id)
    {
        _bowlingBallService.DeleteBowlingBall(id);
        return Ok("Bowling ball deleted.");
    }

    [HttpPut("{id}")]
    public IActionResult EditBall(int id, [FromBody] BowlingBalls ball)
    {
        _bowlingBallService.EditBowlingBall(ball.Id);
        return Ok("Bowling ball updated.");
    }
}
