﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_User.Model;
using Api_User.Services.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace Api_User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private ILogger _logger;
        private IUserService _service;

        public UserController(IUserService service, ILogger<UserController> logger)
        {
            _service = service;
            _logger = logger;
        }


        [HttpGet]
        public ObjectResult Get()
        {
            try
            {
                var users = _service.GetUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("{id}")]
        public ObjectResult Get(int id)
        {
            try
            {
                var user = _service.GetUserByiD(id);
                return Ok(user);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ObjectResult Post([FromBody] UserEntity entity)
        {
            try
            {
                var newEntity = _service.AddUser(entity);
                return Ok(newEntity);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ObjectResult Put(int id, [FromBody] UserEntity entity)
        {
            try
            {
                var user = _service.UpdateUser(id,entity);
                return Ok(user);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ObjectResult Delete(int id)
        {
            try
            {
                var response = _service.DeleteUser(id);
                return Ok(response);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
