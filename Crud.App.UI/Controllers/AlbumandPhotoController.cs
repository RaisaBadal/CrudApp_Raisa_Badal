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
    public class AlbumandPhotoController : ControllerBase
    {
        private readonly IAlbumAndPhotoRepos service;
        public AlbumandPhotoController(IAlbumAndPhotoRepos service)
        {
            this.service = service;
        }
        [HttpGet("getAllAlbum")]

       public IActionResult getAllAlbum()
        {
            try
            {
                var res = service.getAllAlbum();
                if (res == null) return NotFound(" not found Album");
                return Ok(res);
            }
            catch (Exception)
            {
                return StatusCode(200, "SOMETHINGS UNUSUAL");
            }
        }
        [HttpPost("getPhotosByAlbumId")]
        public IActionResult getPhotosByAlbumId(PhotoByAlbumId albumid)
        {
            try
            {
                if (albumid == null) return BadRequest(" No argument  found");
                var result = service.getPhotosByAlbumId(albumid);
                if (result == null) return NotFound(" no Photo found For this Album");
                return Ok(result);
            }
            catch (Exception)
            {

                return StatusCode(100, " unusual");
            }
        }
        [HttpPost("getAlbumByUserId")]
        public IActionResult getAlbumByUserId(AlbumByUserId userid)
        {
            try
            {
                if (userid == null) return BadRequest(" No argument  found");
                var result = service.getAlbumByUserId(userid);
                if (result == null) return NotFound(" no album found For this user");
                return Ok(result);
            }
            catch (Exception)
            {

                return StatusCode(100, " unusual");
            }
        }
    }
}
