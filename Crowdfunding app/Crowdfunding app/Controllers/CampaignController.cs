using Crowdfunding_app.Models;
using Crowdfunding_app.Services;
using Microsoft.AspNetCore.Mvc;
using Crowdfunding_app.Models; 
using Crowdfunding_app.Services;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CampaignController : ControllerBase
    {
        private readonly CampaignService _campaignService;

        // Constructor to inject the CampaignService
        public CampaignController(CampaignService campaignService)
        {
            _campaignService = campaignService;
        }

        // GET api/campaigns
        [HttpGet]
        public ActionResult<IEnumerable<Campaign>> GetAllCampaigns()
        {
            var campaigns = _campaignService.GetCampaignsAsync();
            return Ok(campaigns);
        }

        // GET api/campaigns/{id}
        [HttpGet("{id}")]
        public ActionResult<Campaign> GetCampaignById(int id)
        {
            var campaign = _campaignService.GetCampaignById(id);
            if (campaign == null)
            {
                return NotFound();
            }
            return Ok(campaign);
        }

        // POST api/campaigns
        [HttpPost]
        public ActionResult<Campaign> CreateCampaign([FromBody] Campaign campaign)
        {
            if (campaign == null)
            {
                return BadRequest();
            }

            var createdCampaign = _campaignService.AddCampaignAsync(campaign);
            return CreatedAtAction(nameof(GetCampaignById), new { id = createdCampaign.Id }, createdCampaign);
        }

        // PUT api/campaigns/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCampaign(int id, [FromBody] Campaign campaign)
        {
            if (id != campaign.ID)
            {
                return BadRequest();
            }

            var updated = _campaignService.UpdateCampaignAsync(campaign);
            if (updated == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE api/campaigns/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCampaign(int id)
        {
            var deleted = _campaignService.DeleteCampaignAsync(id);
            if (deleted == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
