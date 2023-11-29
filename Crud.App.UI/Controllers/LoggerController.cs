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
    public class LoggerController : ControllerBase
    {
        private readonly ILogRepos service;
        public LoggerController(ILogRepos service)
        {
            this.service = service;
        }
        [HttpGet("All")]
      public IActionResult  GetAllLogs()
        {
            try
            {
                var res = service.GetAllLogs();
                if (res == null) return NotFound(" not found Logs");
                return Ok(res);
            }
            catch (Exception)
            {
                return StatusCode(200, "SOMETHINGS UNUSUAL");
            }
        }
        [HttpPost("AllBetweenDate")]
        public IActionResult  GetAllLogsBetweenDate(LogsBetweenDate logsbetweendate)
        {
            try
            {
                if (logsbetweendate == null) return BadRequest(" No argument  found");
                var result = service.GetAllLogsBetweenDate(logsbetweendate);
                if (result == null) return NotFound(" no log found For this date");
                return Ok(result);
            }
            catch (Exception)
            {

                return StatusCode(100, " unusual");
            }
        }
    }
}
