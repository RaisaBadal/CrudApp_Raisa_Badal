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
    public class UserController : ControllerBase
    {
        private readonly IUser service;

        public UserController(IUser service)
        {
            this.service = service;
        }

        [HttpPost("Insert")]
        public IActionResult InsertUser(InsertUsers insertuser)//bool
        {
            try
            {

                if (insertuser == null) return BadRequest("Inicialize data  , at first");
                var result = service.InsertUser(insertuser);
                if (result == false) return NotFound("Unsucessfull");

                return Ok(" success Registration");

            }
            catch (Exception exp)
            {
                return StatusCode(234, " somethings unusual");
            }
        }

        [HttpPut("Update")]
        public IActionResult UpdateUser(UpdateUser updateUser)
        {
            try
            {

                if (updateUser == null) return BadRequest("Inicialize data  , at first");
                var result = service.UpdateUser(updateUser);
                if (result == false) return NotFound("Unsucessfull");

                return Ok(" success Update");

            }
            catch (Exception exp)
            {
                return StatusCode(234, " somethings unusual");
            }
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "ManagerOnly")]
        [HttpPost("SoftDelete")]
       public  IActionResult SoftDeleteUser(SoftDeleteUser deleteuser)
        {
            try
            {

                if (deleteuser == null) return BadRequest("Inicialize data  , at first");
                var result = service.SoftDeleteUser(deleteuser);
                if (result == false) return NotFound("Unsucessfull soft delete");

                return Ok(" success soft deleted");

            }
            catch (Exception exp)
            {
                return StatusCode(234, " somethings unusual");
            }
        }
        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            try
            {
                var res = service.GetAllUsers();
                if (res == null) return NotFound(" not found users");
                return Ok(res);
            }
            catch (Exception)
            {
                return StatusCode(200, "SOMETHINGS UNUSUAL");
            }
            
        }

        [HttpPost("GetUserByID")]
        public IActionResult GetUserByID(GetUserbyId userid)
        {
            try
            {
                if (userid == null) return BadRequest(" No argument  found");
                var result = service.GetUserByID(userid);
                if (result == null) return NotFound(" no user found");
                return Ok(result);
            }
            catch (Exception)
            {

                return StatusCode(100, " unusual");
            }
        }
    }
}
