using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_User.Dto;
using Api_User.Model;
using Api_User.Services.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace Api_User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private ILogger _logger;
        private IUserService _service;

        public AuthController(IUserService service, ILogger<UserController> logger)
        {
            _service = service;
            _logger = logger;
        }


        

        [HttpPost]
        public ObjectResult Login([FromBody] AuthDTO authDTO)
        {
            try
            {
                var response = _service.Login(authDTO);
                return Ok(response);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        
        }
    }

