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
    public class ToDoContoller : ControllerBase
    {
        private readonly IToDo service;

        public ToDoContoller(IToDo service)
        {
            this.service = service;
        }

        [HttpGet("AllToDo")]
        public IActionResult GetAllUsers()
        {
            try
            {
                var res = service.GetToDo();
                if (res == null) return NotFound(" not found ToDo");
                return Ok(res);
            }
            catch (Exception)
            {
                return StatusCode(200, "SOMETHINGS UNUSUAL");
            }

        }
        [HttpPost("ToDoByUserId")]
        public IActionResult ToDoByUserId(GetToDoByUserID gettodo)
        {
            try
            {
                if (gettodo == null) return BadRequest(" No argument  found");
                var result = service.ToDoByUserId(gettodo);
                if (result == null) return NotFound(" no ToDo found For this User");
                return Ok(result);
            }
            catch (Exception)
            {

                return StatusCode(100, " unusual");
            }
        }
    }
}
