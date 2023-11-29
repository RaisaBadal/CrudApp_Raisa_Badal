using Crud.App.Core.Interfaces;
using Crud.App.DataSource.ResponceAndRequest;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crud.App.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegAndSignInController : ControllerBase
    {
        private readonly IRegAndSignIn services;
        public RegAndSignInController(IRegAndSignIn services)
        {
            this.services = services;
        }
        [HttpPost("RegistrationManager")]
        public IActionResult RegistrationManager(InsertManager signUp)
        {
            try
            {

                if (signUp == null) return BadRequest("Inicialize data  , at first");
                var result = services.RegistrationManager(signUp);
                if (result == null) return NotFound("Unsucessfull");

                return Ok(" success Registration");

            }
            catch (Exception exp)
            {
                return StatusCode(234, " somethings unusual");
            }
        }
        [HttpPost("SIGNIN")]
        public IActionResult SignIn(GetManagerAuthent manAuth)
        {
            try
            {

                if (manAuth == null) return BadRequest("Inicialize data at first");
                var result = services.SignIn(manAuth);
                if (result == null) return NotFound("Unsucessfull");

                return Ok(result);

            }
            catch (Exception exp)
            {
                return StatusCode(234, " somethings unusual");
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "ManagerOnly")]
        [HttpPost("getalldatafromresource")]
        public IActionResult getalldatafromresource()
        {
            try
            {

               
                if (services.getalldatafromresource()==true)
                {
                    return Ok("Success");
                }
                return BadRequest("Something is wrong");

            }
            catch (Exception exp)
            {
                // return StatusCode(234, " somethings unusual");
                Console.WriteLine(exp.Message);
                Console.WriteLine(exp.StackTrace);
                return StatusCode(102,exp.Message);
            }
        }


    }
}
