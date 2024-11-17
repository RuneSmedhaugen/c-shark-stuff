using Microsoft.AspNetCore.Mvc;
using SwoyerOrbiloUniverse.Model;
using SwoyerOrbiloUniverse.Services;

[Route("api/[controller]")]
[ApiController]
public class GroupController : ControllerBase
{
    private readonly WikiService _wikiService;

    public GroupController(WikiService wikiService)
    {
        _wikiService = wikiService;
    }

    // GET: api/Group
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Group>>> GetGroups()
    {
        var groups = await _wikiService.GetGroupsAsync();
        return Ok(groups);
    }

    // GET: api/Group/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Group>> GetGroup(int id)
    {
        var group = await _wikiService.GetGroupByIdAsync(id);

        if (group == null)
        {
            return NotFound();
        }

        return Ok(group);
    }

    // POST: api/Group
    [HttpPost]
    public async Task<ActionResult<Group>> PostGroup(Group group)
    {
        await _wikiService.AddGroupAsync(group);
        return CreatedAtAction("GetGroup", new { id = group.Id }, group);
    }

    // PUT: api/Group/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutGroup(int id, Group group)
    {
        if (id != group.Id)
        {
            return BadRequest();
        }

        await _wikiService.UpdateGroupAsync(group);
        return NoContent();
    }

    // DELETE: api/Group/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGroup(int id)
    {
        await _wikiService.DeleteGroupAsync(id);
        return NoContent();
    }
}