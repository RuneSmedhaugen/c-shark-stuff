using Crowdfunding_app.Models;
using Crowdfunding_app.Services;
using Microsoft.AspNetCore.Mvc;

namespace Crowdfunding_app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CampaignController : ControllerBase
    {
        private readonly CampaignService _campaignService;

        public CampaignController(CampaignService campaignService)
        {
            _campaignService = campaignService;
        }

        // GET api/campaigns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Campaign>>> GetAllCampaigns()
        {
            var campaigns = await _campaignService.GetCampaignsAsync();
            return Ok(campaigns);
        }

        // GET api/campaigns/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Campaign>> GetCampaignById(int id)
        {
            var campaign = await _campaignService.GetCampaignByIdAsync(id);
            if (campaign == null)
            {
                return NotFound();
            }

            return Ok(campaign);
        }

        // POST api/campaigns
        [HttpPost]
        public async Task<ActionResult<Campaign>> CreateCampaign([FromBody] Campaign campaign)
        {
            if (campaign == null)
            {
                return BadRequest();
            }

            await _campaignService.AddCampaignAsync(campaign);
            return CreatedAtAction(nameof(GetCampaignById), new { id = campaign.ID }, campaign);
        }

        // PUT api/campaigns/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCampaign(int id, [FromBody] Campaign campaign)
        {
            if (id != campaign.ID)
            {
                return BadRequest();
            }

            var existingCampaign = await _campaignService.GetCampaignByIdAsync(id);
            if (existingCampaign == null)
            {
                return NotFound();
            }

            await _campaignService.UpdateCampaignAsync(campaign);
            return NoContent();
        }

        // DELETE api/campaigns/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCampaign(int id)
        {
            var existingCampaign = await _campaignService.GetCampaignByIdAsync(id);
            if (existingCampaign == null)
            {
                return NotFound();
            }

            await _campaignService.DeleteCampaignAsync(id);
            return NoContent();
        }
    }
}
