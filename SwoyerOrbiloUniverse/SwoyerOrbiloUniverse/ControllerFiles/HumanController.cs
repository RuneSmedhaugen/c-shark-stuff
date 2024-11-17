using Microsoft.AspNetCore.Mvc;
using SwoyerOrbiloUniverse.Model;
using SwoyerOrbiloUniverse.Services;

[Route("api/[controller]")]
[ApiController]
public class HumanController : ControllerBase
{
    private readonly WikiService _wikiService;

    public HumanController(WikiService wikiService)
    {
        _wikiService = wikiService;
    }

    // GET: api/Human
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Human>>> GetHumans()
    {
        var humans = await _wikiService.GetHumansAsync();
        return Ok(humans);
    }

    // GET: api/Human/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Human>> GetHuman(int id)
    {
        var human = await _wikiService.GetHumanByIdAsync(id);

        if (human == null)
        {
            return NotFound();
        }

        return Ok(human);
    }

    // POST: api/Human
    [HttpPost]
    public async Task<ActionResult<Human>> PostHuman(Human human)
    {
        await _wikiService.AddHumanAsync(human);
        return CreatedAtAction("GetHuman", new { id = human.Id }, human);
    }

    // PUT: api/Human/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutHuman(int id, Human human)
    {
        if (id != human.Id)
        {
            return BadRequest();
        }

        await _wikiService.UpdateHumanAsync(human);
        return NoContent();
    }

    // DELETE: api/Human/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHuman(int id)
    {
        await _wikiService.DeleteHumanAsync(id);
        return NoContent();
    }
}