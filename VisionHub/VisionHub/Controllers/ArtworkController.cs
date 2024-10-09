using Microsoft.AspNetCore.Mvc;
using VisionHub.Models;
using VisionHub.Services;

namespace VisionHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtworkController : ControllerBase
    {
        private readonly ArtworkService _artworkService;

        public ArtworkController(ArtworkService artworkService)
        {
            _artworkService = artworkService;
        }

        // POST api/artwork/add
        [HttpPost("add")]
        public IActionResult AddArtwork([FromBody] Artworks model)
        {
            try
            {
                _artworkService.AddArt(model.UserID, model.Title, model.Description, model.ImageUrl);
                return Ok(new { message = "Artwork added successfully!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // GET api/artwork/{id}
        [HttpGet("{id}")]
        public IActionResult GetArtwork(int id)
        {
            var artworks = _artworkService.GetArtId(id);
            if (artworks == null || artworks.Count == 0)
            {
                return NotFound();
            }
            return Ok(artworks);
        }

        // GET api/artwork
        [HttpGet]
        public IActionResult GetAllArtworks()
        {
            var artworks = _artworkService.GetAllArt();
            return Ok(artworks);
        }

        // PUT api/artwork/update/{id}
        [HttpPut("update/{id}")]
        public IActionResult UpdateArtwork(int id, [FromBody] Artworks model)
        {
            try
            {
                _artworkService.UpdateArt(id, model.Title, model.Description, model.ImageUrl);
                return Ok(new { message = "Artwork updated successfully!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // DELETE api/artwork/delete/{id}
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteArtwork(int id)
        {
            try
            {
                _artworkService.DeleteArt(id);
                return Ok(new { message = "Artwork deleted successfully!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
