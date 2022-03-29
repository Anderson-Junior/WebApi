using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Models.InputModels;
using WebApi.Services.Auth;
using WebApi.Services.Users;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UserController(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{id}", Name = "GetUserById")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> GetUserById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(await _service.GetUserByIdAsync(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] UserInputModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var us = _mapper.Map<User>(user);
                var result = await _service.PostUserAsync(us);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetUserById", new { id = result.Id })), result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
