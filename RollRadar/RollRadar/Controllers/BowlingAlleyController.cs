using Microsoft.AspNetCore.Mvc;
using RollRadar.Models;
/*
[ApiController]
[Route("api/[controller]")]
public class BowlingAlleyController : ControllerBase
{
    private readonly BowlingAlleyService _bowlingAlleyService;

    public BowlingAlleyController(BowlingAlleyService bowlingAlleyService)
    {
        _bowlingAlleyService = bowlingAlleyService;
    }

    [HttpGet]
    public IActionResult GetAllAlleys()
    {
        var alleys = _bowlingAlleyService.ViewAllBowlingAlleys();
        return Ok(alleys);
    }

    [HttpPost]
    public IActionResult AddAlley([FromBody] BowlingAlleys alley)
    {
        _bowlingAlleyService.AddBowlingAlley(alley.UserId);
        return Ok("Bowling alley added.");
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAlley(int id)
    {
        _bowlingAlleyService.DeleteBowlingAlley(id);
        return Ok("Bowling alley deleted.");
    }

    [HttpPut("{id}")]
    public IActionResult EditAlley(int id, [FromBody] BowlingAlleys alley)
    {
        _bowlingAlleyService.EditBowlingAlley(id, alley);
        return Ok("Bowling alley updated.");
    }
}
*/