using Microsoft.AspNetCore.Mvc;
using SwoyerOrbiloUniverse.Model;
using SwoyerOrbiloUniverse.Services;

[Route("api/[controller]")]
[ApiController]
public class EntityController : ControllerBase
{
    private readonly WikiService _wikiService;

    public EntityController(WikiService wikiService)
    {
        _wikiService = wikiService;
    }

    // GET: api/Entity
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Entity>>> GetEntities()
    {
        var entities = await _wikiService.GetEntitiesAsync();
        return Ok(entities);
    }

    // GET: api/Entity/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Entity>> GetEntity(int id)
    {
        var entity = await _wikiService.GetEntityByIdAsync(id);

        if (entity == null)
        {
            return NotFound();
        }

        return Ok(entity);
    }

    // POST: api/Entity
    [HttpPost]
    public async Task<ActionResult<Entity>> PostEntity(Entity entity)
    {
        await _wikiService.AddEntityAsync(entity);
        return CreatedAtAction("GetEntity", new { id = entity.Id }, entity);
    }

    // PUT: api/Entity/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutEntity(int id, Entity entity)
    {
        if (id != entity.Id)
        {
            return BadRequest();
        }

        await _wikiService.UpdateEntityAsync(entity);
        return NoContent();
    }

    // DELETE: api/Entity/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEntity(int id)
    {
        await _wikiService.DeleteEntityAsync(id);
        return NoContent();
    }
}