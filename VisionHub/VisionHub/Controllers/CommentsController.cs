﻿using Microsoft.AspNetCore.Mvc;
using VisionHub.Models;
using VisionHub.Services;

namespace VisionHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly CommentService _commentService;

        public CommentController(CommentService commentService)
        {
            _commentService = commentService;
        }

        // POST api/comment/add
        [HttpPost("add")]
        public IActionResult AddComment([FromBody] Comments model)
        {
            if (model == null)
            {
                return BadRequest(new { message = "Invalid comment data." });
            }

            try
            {
                _commentService.AddComment(model.ArtworkID, model.UserID, model.CommentText);
                return Ok(new { message = "Comment added successfully!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // GET api/comment/{id}
        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var comments = _commentService.GetAllComments(id); // Assuming this method returns comments for a specific artwork

            if (comments == null || comments.Count == 0)
            {
                return NotFound(new { message = "No comments found." });
            }

            return Ok(comments);
        }

        // GET api/comment/artwork/{artworkId}
        [HttpGet("artwork/{artworkId}")]
        public IActionResult GetCommentsByArtwork(int artworkId)
        {
            var comments = _commentService.GetAllComments(artworkId);
            if (comments == null || comments.Count == 0)
            {
                return NotFound(new { message = "No comments found for this artwork." });
            }
            return Ok(comments);
        }

        // PUT api/comment/update/{id}
        [HttpPut("update/{id}")]
        public IActionResult UpdateComment(int id, [FromBody] Comments model)
        {
            if (model == null)
            {
                return BadRequest(new { message = "Invalid comment data." });
            }

            try
            {
                _commentService.UpdateComment(id, model.CommentText);
                return Ok(new { message = "Comment updated successfully!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // DELETE api/comment/delete/{id}
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteComment(int id)
        {
            try
            {
                _commentService.RemoveComment(id);
                return Ok(new { message = "Comment deleted successfully!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
