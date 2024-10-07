using Microsoft.AspNetCore.Mvc;
using RollRadar.Models;

[ApiController]
[Route("api/[controller]")]
public class ScoreController : ControllerBase
{
    private readonly ScoreService _scoreService;

    public ScoreController(ScoreService scoreService)
    {
        _scoreService = scoreService;
    }

    [HttpGet]
    public IActionResult GetAllScores()
    {
        var scores = _scoreService.ViewAllScores();
        return Ok(scores);
    }


        [HttpPost]
    public IActionResult AddScore([FromBody] Scores score)
    {
        _scoreService.AddScore();
        return Ok("Score added.");
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteScore(int id)
    {
        _scoreService.DeleteScore(id);
        return Ok("Score deleted.");
    }

    [HttpPut("{id}")]
    public IActionResult EditScore(int id, [FromBody] Scores score)
    {
        _scoreService.EditScore(id);
        return Ok("Score updated.");
    }
}