using Crud.App.Core.Interfaces;
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
    public class ErrorController : ControllerBase
    {
        private readonly IErrorRepos service;
        public ErrorController(IErrorRepos service)
        {
            this.service = service;
        }
        [HttpGet("All")]
        public IActionResult GetAllError()
        {
            try
            {
                var res = service.GetAllError();
                if (res == null) return NotFound(" not found Error");
                return Ok(res);
            }
            catch (Exception)
            {
                return StatusCode(200, "SOMETHINGS UNUSUAL");
            }
        }
        [HttpPost("AllBetweenDate")]
        public IActionResult GetAllErrorsBetWeenDate(ErrorBetweenData errorbetweendate)
        {
            try
            {
                if (errorbetweendate == null) return BadRequest(" No argument  found");
                var result = service.GetAllErrorsBetWeenDate(errorbetweendate);
                if (result == null) return NotFound(" no error found For this date");
                return Ok(result);
            }
            catch (Exception)
            {

                return StatusCode(100, " unusual");
            }
        }
    }
}
