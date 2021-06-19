using AuthorizationMicroservice.Models;
using AuthorizationMicroservice.Repository;
using AuthorizationMicroservice.Service;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IService _service;
        public AuthorizationController(IService service)
        {
            this._service = service;
        }

        [HttpPost]
        [Route("getToken")]
        public IActionResult GenerateToken([FromBody] LoginForm credential)
        {
            try
            {
                log.Info("Generating token using login credentials");
                string token = _service.GetToken(credential.UserName, credential.Password);
                if (token != null)
                {
                    return Ok(token);
                }
                return Unauthorized("Invalid Credentials");
            }
            catch (Exception e)
            {
                log.Error("Error Occured while generating token" + e.Message);
                return BadRequest("Some error ocurred! " + e.Message);
            }             
        }
    }
}
