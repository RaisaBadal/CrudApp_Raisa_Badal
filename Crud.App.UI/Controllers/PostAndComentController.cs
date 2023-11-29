using Crud.App.Core.Interfaces;
using Crud.App.Core.Models;
using Crud.App.DataSource.ResponceAndRequest;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudApp.UI.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class PostAndComentController : ControllerBase
    {
        private readonly IPostAndCommentRepos service;
        public PostAndComentController(IPostAndCommentRepos service)
        {
            this.service = service;
        }
        [HttpGet("GetAllPost")]
       public IActionResult GetAllPost()
        {
            try
            {
                var res = service.GetAllPost();
                if (res == null) return NotFound(" not found Posts");
                return Ok(res);
            }
            catch (Exception)
            {
                return StatusCode(200, "SOMETHINGS UNUSUAL");
            }
        }
        [HttpPost("GetAllCommentsByPostID")]
        public IActionResult GetAllCommentsByPostID(CommentByPostId commentbyId)
        {
            try
            {
                if (commentbyId == null) return BadRequest(" No argument  found");
                var result = service.GetAllCommentsByPostID(commentbyId);
                if (result == null) return NotFound(" no Comment found For this Post");
                return Ok(result);
            }
            catch (Exception)
            {

                return StatusCode(100, " unusual");
            }
        }
        [HttpPost("GetPostByUserID")]
        public IActionResult GetPostByUserID(PostByUserId userid)
        {
            try
            {
                if (userid == null) return BadRequest("No argument found");
                var result=service.GetPostByUserID(userid);
                if (result == null) return NotFound("No Post fount for this User");
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(100, "unusual");
            }
        }
    }
}
